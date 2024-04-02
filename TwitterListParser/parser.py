import json

# Ruta al archivo .txt que contiene los nombres de usuario
ruta_archivo_txt = 'usuarios_twitter.txt'  # Asegúrate de actualizar esta ruta

# Ruta al archivo JSON de salida
ruta_archivo_json = 'usuarios_twitter.json'  # Asegúrate de actualizar esta ruta si es necesario

# Leer los nombres de usuario del archivo .txt
with open(ruta_archivo_txt, 'r') as archivo:
    # Utilizamos un conjunto (set) para eliminar duplicados automáticamente
    nombres_usuarios = set(archivo.read().splitlines())

# Realizar "trim" y eliminar el símbolo @ de los nombres de usuario y crear el diccionario
usuarios_dict = {nombre_usuario.strip().strip('@'): 1 for nombre_usuario in nombres_usuarios}

# Guardar el diccionario en un archivo .json
with open(ruta_archivo_json, 'w') as archivo_json:
    json.dump(usuarios_dict, archivo_json, indent=4)

print(f'Archivo JSON generado exitosamente: {ruta_archivo_json}')

