from flask import Flask, jsonify, request
import json
import csv
import xml.etree.ElementTree as ET
import yaml

app = Flask(__name__)



# Endpoint for JSON data
@app.route('/json', methods=['GET'])
def get_json_data():
    return jsonify(name=json_name, age=json_age, hobbies=json_hobbies)

# Endpoint for CSV data
@app.route('/csv', methods=['GET'])
def get_csv_data():
     return jsonify(name=csv_name, age=csv_age, hobbies=csv_hobbies)

 # Endpoint for XML data
@app.route('/xml', methods=['GET'])
def get_xml_data():
     return jsonify(name=xml_name, age=xml_age, hobbies=xml_hobbies)

 # Endpoint for YAML data
@app.route('/yaml', methods=['GET'])
def get_yaml_data():
     return jsonify(name=yaml_name, age=yaml_age, hobbies=yaml_hobbies)

 # Endpoint for TXT data
@app.route('/txt', methods=['GET'])
def get_txt_data():
     return jsonify(name=txt_name, age=txt_age, hobbies=txt_hobbies)

if __name__ == '__main__':
    app.run(debug=True)