# BackgroundWorker

因为某些关系去掉了 appsetting.json和appsetting.Development.json,这两个文件需要自己手动添加,文件建好复制下面的配置保存即可。
```
{
  "Logging": {
    "LogLevel": {
      "Default": "Information",
      "Microsoft": "Warning",
      "Microsoft.Hosting.Lifetime": "Information"
    }
  },
  "ConnectionStrings": {
    "Connection_SqlServer": "Server=localhost;Database=HCVision;User Id=sa;Password=xxx;"
  }
}
```
