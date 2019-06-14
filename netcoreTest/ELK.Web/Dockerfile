FROM  microsoft/dotnet:latest
WORKDIR /app

COPY . ./
EXPOSE 80

ENTRYPOINT ["dotnet", "ELK.Web.dll"]