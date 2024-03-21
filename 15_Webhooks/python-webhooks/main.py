from fastapi import FastAPI, Request, Response

app = FastAPI()

@app.post("/githubwebhookjson")
async def github_webhook(request: Request):
    data = await request.body()
    print(data)
    return


@app.post("/githubwebhookfrom")
async def github_webhook(request: Request, response: Response):
    if request.headers.get("content-type") == "application/x-www-form-urlencoded":
        from_data = await request.form()
        print(from_data)
        response.status_code = 200
    else:
        response.status_code = 400
    