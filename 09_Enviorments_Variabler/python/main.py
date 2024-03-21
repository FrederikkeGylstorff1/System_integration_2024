from dotenv import dotenv_values, load_dotenv


#exempel 1
environmet_varibels = dotenv_values()
print(environmet_varibels)




#exempel 

import os

load_dotenv()
print(os.getenv["PASSWORED"])