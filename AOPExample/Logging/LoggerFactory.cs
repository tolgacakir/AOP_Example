using System;
using System.Collections.Generic;
using System.Text;
using Serilog;
using Serilog.Sinks.MSSqlServer;

namespace AOPExample.Logging
{
    public class LoggerFactory
    {
        public static Serilog.ILogger GetSerilogSqlLogger()
        {
            return new LoggerConfiguration()
                .MinimumLevel.Verbose()
                .WriteTo.MSSqlServer(
                    connectionString: @"Data Source=ENDOS\MSSQLSERVER2;Initial Catalog=ENDOS_MNG_3402;Integrated Security=True",
                    sinkOptions: new MSSqlServerSinkOptions { TableName = "Serilogs", AutoCreateSqlTable = true })
                .CreateLogger();

        }

        public static Serilog.ILogger GetSerilogFileLogger(int retainedFileCountLimit = 2)
        {
            return new LoggerConfiguration()
                .WriteTo.File(
                    path: "logs\\log.txt",
                    outputTemplate: "{Timestamp:yyyy-MM-dd HH:mm:ss.fff zzz} [{Level:u3}] {Message:lj}{NewLine}{Exception}",
                    rollingInterval: RollingInterval.Day,
                    fileSizeLimitBytes: 500000000,//500Mb
                    rollOnFileSizeLimit: true,
                    retainedFileCountLimit: retainedFileCountLimit)
                .MinimumLevel.Verbose()
                .CreateLogger();
        }

        public static Serilog.ILogger GetSerilogAsyncFileLogger(int retainedFileCountLimit = 2)
        {
            return new LoggerConfiguration()
                .WriteTo.Async(a =>
                {
                    a.File(
                        path: "logs\\log.txt",
                        outputTemplate: "{Timestamp:yyyy-MM-dd HH:mm:ss.fff zzz} [{Level:u3}] {Message:lj}{NewLine}{Exception}",
                        rollingInterval: RollingInterval.Day,
                        fileSizeLimitBytes: 500000000,//500Mb
                        rollOnFileSizeLimit: true,
                        retainedFileCountLimit: retainedFileCountLimit);
                })
                .MinimumLevel.Verbose()
                .CreateLogger();
        }
    }
}
