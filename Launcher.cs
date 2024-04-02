using System.Threading;

namespace PinkyExocet
{
    public partial class Launcher : Form
    {

        private BlockListManager blockListManager;
        private CancellationTokenSource cancellationTokenSource;
        private Mp3Player mp3Player;
        public Launcher()
        {
            InitializeComponent();
            blockListManager = new BlockListManager();
            cancellationTokenSource = new CancellationTokenSource();
            mp3Player = new Mp3Player();

        }

        private void Form1_Load(object sender, EventArgs e)
        {


        }

        public static string RemoveAtIfFirst(string input)
        {
            // Verifica si el string no est� vac�o y si el primer car�cter es un arroba.
            if (!string.IsNullOrEmpty(input) && input.StartsWith("@"))
            {
                // Remueve el primer car�cter y devuelve el string resultante.
                return input.Substring(1);
            }

            // Si no se cumplen las condiciones, devuelve el string original.
            return input;
        }

        private async void btnStart_Click(object sender, EventArgs e)
        {
            btnDetener.Visible = true;
            var twitterBot = new TwitterBot(txtUser.Text, txtPass.Text, flagDobleFactor.Checked);
            await twitterBot.LoginAsync(cancellationTokenSource.Token); // Asumiendo que ahora LoginAsync es as�ncrono

            foreach (var x in SplitStringIntoLines(txtUsersToBlock.Text))
            {
                if (cancellationTokenSource.Token.IsCancellationRequested)
                {
                    twitterBot.Stop();
                    return;
                }
                try
                {
                    var cleanUser = RemoveAtIfFirst(x.Trim());
                    if (!await blockListManager.IsInTheListAsync(cleanUser, cancellationTokenSource.Token)){
                        await twitterBot.BlockUserAsync(cleanUser, cancellationTokenSource.Token); // Suponiendo que BlockUser es ahora BlockUserAsync y es as�ncrono
                        await blockListManager.SaveInTheListAsync(cleanUser);
                    }
                        
                }
                catch (Exception)
                {
                    continue;
                }
            }

            foreach (var x in SplitStringIntoLines(txtListas.Text))
            {
                var keyValue = await JsonDownloader.DownloadAndParseJsonAsync(x, cancellationTokenSource.Token); // Aseg�rate de que DownloadAndParseJson se convierta en DownloadAndParseJsonAsync
                foreach (var kv in keyValue)
                {
                    if (cancellationTokenSource.Token.IsCancellationRequested)
                    {
                        twitterBot.Stop();
                        return;
                    }
                    try
                    {
                        if (!await blockListManager.IsInTheListAsync(kv.Key, cancellationTokenSource.Token))
                        {
                            await twitterBot.BlockUserAsync(kv.Key, cancellationTokenSource.Token); // Usa la versi�n as�ncrona
                            await blockListManager.SaveInTheListAsync(kv.Key);
                        }
                            
                    }
                    catch (Exception)
                    {

                        continue;
                    }
                }
            }
        }


        public static List<string> SplitStringIntoLines(string input)
        {
            // Divide el string en l�neas usando los caracteres de nueva l�nea como delimitadores
            // Considera tanto el salto de l�nea de Unix/Linux (\n) como el de Windows (\r\n)
            string[] lines = input.Split(new[] { "\r\n", "\r", "\n" }, StringSplitOptions.None);

            // Convierte el arreglo de strings en una lista y la devuelve
            List<string> listOfLines = new List<string>(lines);
            return listOfLines;
        }

        private void btnDetener_Click(object sender, EventArgs e)
        {
            btnDetener.Visible = false;
            cancellationTokenSource.Cancel();

        }

        bool isPlaying = false; 

        private async void fotito_Click(object sender, EventArgs e)
        {
            if(isPlaying)
            {
                isPlaying = false;
                mp3Player.Stop();
            }
            else
            {
                isPlaying = true;
                await mp3Player.PlayAsync("malvinas.mp3");
            }            
            
        }
    }
}