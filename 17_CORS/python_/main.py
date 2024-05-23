from fastapi import FastAPI
from fastapi.middleware.cors import CORSMiddleware
from datetime import datetime

print(datetime.now())

app = FastAPI()

# # Configure CORS
# origins = [
#     "http://localhost",
#     "http://localhost:8080",
# ]

app.add_middleware(
     CORSMiddleware,
     allow_origins=["*"],
     allow_credentials=True,
     allow_methods=["*"],
     allow_headers=["*"],
)


@app.get("/timestamp")
def get_timestamp():
    # Your code to get the timestamp goes here
    return {"timestamp": datetime.now()}
