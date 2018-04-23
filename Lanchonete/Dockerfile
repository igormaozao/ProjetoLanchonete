FROM microsoft/aspnetcore:1.1
ARG source
WORKDIR /app
EXPOSE 57700
COPY ${source:-obj/Docker/publish} .
ENTRYPOINT ["dotnet", "Lanchonete.dll"]
