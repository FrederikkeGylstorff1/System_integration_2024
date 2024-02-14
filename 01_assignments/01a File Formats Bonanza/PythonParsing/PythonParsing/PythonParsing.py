
import json
import csv

# Reading and parsing JSON file
with open(r'C:\Users\frede\source\repos\System_integration_2024\01a File Formats Bonanza\PythonParsing\PythonParsing\me.json', 'r') as json_file:
    json_data = json.load(json_file)
    json_name = json_data['navn']
    json_age = json_data['alder']
    json_hobbies = json_data['fritid']

# Reading and parsing CSV file
with open(r'C:\Users\frede\source\repos\System_integration_2024\01a File Formats Bonanza\PythonParsing\PythonParsing\me.csv', 'r') as csv_file:
    csv_reader = csv.DictReader(csv_file)
    csv_data = next(csv_reader)
    csv_name = csv_data['name']
    csv_age = int(csv_data[' age'])  
    csv_hobbies = csv_data[' fritid'].split(', ') 

# Displaying parsed data
print(f"JSON File: Name: {json_name}, Age: {json_age}, Hobbies: {', '.join(json_hobbies)}")
print(f"CSV File: Name: {csv_name}, Age: {csv_age}, Hobbies: {', '.join(csv_hobbies)}")



