using System;
using System.Collections.Generic;

public interface TestProjectAO
{
    string FetchData();
}

public interface ILogger
{
    void Log(string message);
}

public interface IEmailService
{
    void SendEmail(string message);
}

public interface ICacheService
{
    string Get(string key);
    void Set(string key, string value);
}

public class DataService
{
    private readonly IDataFetcher _dataFetcher;
    private readonly ILogger _logger;
    private readonly IEmailService _emailService;
    private readonly ICacheService _cacheService;

    public DataService(IDataFetcher dataFetcher, ILogger logger, IEmailService emailService, ICacheService cacheService)
    {
        _dataFetcher = dataFetcher;
        _logger = logger;
        _emailService = emailService;
        _cacheService = cacheService;
    }

    public string GetData()
    {
        return _dataFetcher.FetchData();
    }

    public string ProcessData()
    {
        var data = _dataFetcher.FetchData();
        return data.ToUpper();
    }

    public bool ValidateData(string data)
    {
        return !string.IsNullOrEmpty(data);
    }

    public List<string> SplitData(string data)
    {
        return new List<string>(data.Split(','));
    }

    public void LogData(string message)
    {
        _logger.Log(message);
    }

    public void SendNotification(string message)
    {
        _emailService.SendEmail(message);
    }

    public string GetCachedData(string key)
    {
        return _cacheService.Get(key);
    }

    public void CacheData(string key, string data)
    {
        _cacheService.Set(key, data);
    }
}
