import xml.etree.ElementTree as ET
import csv
import json
import yaml

def read_and_print_xml(file_path):
    with open(file_path, 'r') as xml_file:
        xml_tree = ET.parse(xml_file)
        root = xml_tree.getroot()
        print("XML File Content:")
        for child in root:
            print(f"{child.tag}: {child.text}")

def read_and_print_csv(file_path):
    with open(file_path, 'r') as csv_file:
        csv_reader = csv.DictReader(csv_file)
        csv_data = next(csv_reader)
        csv_name = csv_data['name']
        csv_age = int(csv_data[' age'])
        csv_hobbies = csv_data[' fritid'].split(', ')

        print(f"CSV File: Name: {csv_name}, Age: {csv_age}, Hobbies: {', '.join(csv_hobbies)}")

def read_and_print_json(file_path):
    with open(file_path, 'r') as json_file:
        json_data = json.load(json_file)
        json_name = json_data['navn']
        json_age = json_data['alder']
        json_hobbies = json_data['fritid']

        print(f"JSON File: Name: {json_name}, Age: {json_age}, Hobbies: {', '.join(json_hobbies)}")

def read_and_print_yaml(file_path):
    with open(file_path, 'r', encoding='latin-1') as yaml_file:
        yaml_data = yaml.safe_load(yaml_file)
        print("YAML File Content:")
        print(yaml_data)

# Usage
read_and_print_xml('me.xml')
read_and_print_csv('me.csv')
read_and_print_json('me.json')
read_and_print_yaml('me.yml')
