# min løsning på encoding

import base64

# Random string til at encode
random_string = "Hello, World!"

# Encoding af den random string
encoded_string = base64.b64encode(random_string.encode()).decode()
print("Encoded String:", encoded_string)

# Decoding af den encoded string
decoded_string = base64.b64decode(encoded_string).decode()
print("Decoded String:", decoded_string)


# initializing string 
String = "geeksforgeeks"
  
encoded_string = String.encode('utf-8') 
print('The encoded string in base64 format is :') 
print(encoded_string) 
  
decoded_string = encoded_string.decode('utf-8') 
print('The decoded string is :') 
print(decoded_string) 