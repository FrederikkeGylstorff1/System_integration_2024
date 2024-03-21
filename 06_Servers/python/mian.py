from fastapi import FastAPI

app = FastAPI()

@app.get("/")
def root():
    return {"message:" : "wolcome to our first server"}


@app.get("/firstRouter")
def firstRouder():
    return {"message": "this is the first router!"}


# for at køre og realoade 
#uvicorn main:app
#uvicorn main:app -- reload 

