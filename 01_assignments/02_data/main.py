from fastapi import FastAPI, HTTPException
from fastapi.responses import JSONResponse
import xml.etree.ElementTree as ET
import csv
import json
import yaml

app = FastAPI()

@app.get('/xml')
async def get_xml_data():
    try:
        xml_path = 'me.xml'
        data = read_and_print_xml(xml_path)
        return JSONResponse(content={"data": data})
    except Exception as e:
        raise HTTPException(status_code=500, detail=str(e))

@app.get('/csv')
async def get_csv_data():
    try:
        csv_path = 'me.csv'
        data = read_and_print_csv(csv_path)
        return JSONResponse(content={"data": data})
    except Exception as e:
        raise HTTPException(status_code=500, detail=str(e))

@app.get('/json')
async def get_json_data():
    try:
        json_path = 'me.json'
        data = read_and_print_json(json_path)
        return JSONResponse(content={"data": data})
    except Exception as e:
        raise HTTPException(status_code=500, detail=str(e))

@app.get('/yaml')
async def get_yaml_data():
    try:
        yaml_path = 'me.yml'
        data = read_and_print_yaml(yaml_path)
        return JSONResponse(content={"data": data})
    except Exception as e:
        raise HTTPException(status_code=500, detail=str(e))

def read_and_print_xml(file_path):
    with open(file_path, 'r') as xml_file:
        xml_tree = ET.parse(xml_file)
        root = xml_tree.getroot()
        data = []
        for child in root:
            data.append({child.tag: child.text})
        return data

def read_and_print_csv(file_path):
    with open(file_path, 'r') as csv_file:
        csv_reader = csv.DictReader(csv_file)
        csv_data = next(csv_reader)
        csv_name = csv_data['name']
        csv_age = int(csv_data[' age'])
        csv_hobbies = csv_data[' fritid'].split(', ')
        return {"Name": csv_name, "Age": csv_age, "Hobbies": csv_hobbies}

def read_and_print_json(file_path):
    with open(file_path, 'r') as json_file:
        json_data = json.load(json_file)
        json_name = json_data['navn']
        json_age = json_data['alder']
        json_hobbies = json_data['fritid']
        return {"Name": json_name, "Age": json_age, "Hobbies": json_hobbies}

def read_and_print_yaml(file_path):
    with open(file_path, 'r', encoding='latin-1') as yaml_file:
        yaml_data = yaml.safe_load(yaml_file)
        return {"data": yaml_data}
