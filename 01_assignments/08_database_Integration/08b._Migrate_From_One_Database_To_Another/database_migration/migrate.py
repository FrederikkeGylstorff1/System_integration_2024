# migrate.py

import mysql.connector
from .config import source_config, destination_config

def migrate():
    # Connect to source database
    source_conn = mysql.connector.connect(**source_config)
    source_cursor = source_conn.cursor(dictionary=True)

    # Connect to destination database
    destination_conn = mysql.connector.connect(**destination_config)
    destination_cursor = destination_conn.cursor()

    try:
        # Fetch data from source database
        source_cursor.execute("SELECT Name, Email FROM Users")
        rows = source_cursor.fetchall()

        # Insert data into destination database
        insert_query = """
        INSERT INTO Users (Name, Email) VALUES (%s, %s)
        ON DUPLICATE KEY UPDATE Name=VALUES(Name)
        """
        data = [(row['Name'], row['Email']) for row in rows]
        destination_cursor.executemany(insert_query, data)
        destination_conn.commit()

        print(f"{len(rows)} rows migrated successfully.")

    except Exception as e:
        print(f"An error occurred: {e}")
        destination_conn.rollback()
    
    finally:
        # Close connections
        source_cursor.close()
        source_conn.close()
        destination_cursor.close()
        destination_conn.close()
