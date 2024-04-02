namespace PinkyExocet
{
    public partial class Launcher : Form
    {
        private TwitterBot twitterBot;
        private BlockListManager blockListManager;
        public Launcher()
        {
            InitializeComponent();
            blockListManager = new BlockListManager();
        }

        private void Form1_Load(object sender, EventArgs e)
        {


        }

        public static string RemoveAtIfFirst(string input)
        {
            // Verifica si el string no está vacío y si el primer carácter es un arroba.
            if (!string.IsNullOrEmpty(input) && input.StartsWith("@"))
            {
                // Remueve el primer carácter y devuelve el string resultante.
                return input.Substring(1);
            }

            // Si no se cumplen las condiciones, devuelve el string original.
            return input;
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            twitterBot = new TwitterBot(txtUser.Text, txtPass.Text, flagDobleFactor.Checked);
            twitterBot.Login();
            foreach (var x in SplitStringIntoLines(txtUsersToBlock.Text))
            {

                try
                {
                    var cleanUser = RemoveAtIfFirst(x.Trim());
                    if (!blockListManager.IsInTheList(cleanUser))
                        twitterBot.BlockUser(cleanUser);
                    blockListManager.SaveInTheList(cleanUser);
                }
                catch (Exception)
                {


                }
            }

            foreach (var x in SplitStringIntoLines(txtListas.Text))
            {
                var keyValue = JsonDownloader.DownloadAndParseJson(x);
                foreach (var kv in keyValue)
                {
                    try
                    {
                        if (!blockListManager.IsInTheList(kv.Key))
                            twitterBot.BlockUser(kv.Key);
                        blockListManager.SaveInTheList(kv.Key);
                    }
                    catch (Exception)
                    {


                    }

                }
            }
        }


        public static List<string> SplitStringIntoLines(string input)
        {
            // Divide el string en líneas usando los caracteres de nueva línea como delimitadores
            // Considera tanto el salto de línea de Unix/Linux (\n) como el de Windows (\r\n)
            string[] lines = input.Split(new[] { "\r\n", "\r", "\n" }, StringSplitOptions.None);

            // Convierte el arreglo de strings en una lista y la devuelve
            List<string> listOfLines = new List<string>(lines);
            return listOfLines;
        }

    }
}