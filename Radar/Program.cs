﻿// See https://aka.ms/new-console-template for more information
using Microsoft.Extensions.DependencyInjection;
using Radar;
using Radar.Services;
using System.Net;
using System.Net.NetworkInformation;
using System.Net.Sockets;

internal class Program
{
    private async static Task Main(string[] args)
    {
        //setup our DI
        var serviceProvider = new ServiceCollection()
            //.AddLogging()
            .AddSingleton<IIPManipulationService, IPManipulationService>()
            .AddSingleton<INetworkScanner, NetworkScanner>()
            .BuildServiceProvider();

        var ipService = serviceProvider.GetService<IIPManipulationService>();
        var networkService = serviceProvider.GetService<INetworkScanner>();

        var radar = new RadarScanner(ipService, networkService);
        await radar.StartScan();
    }


    public enum ConsoleColors
    {
        Red,
        Yellow,
        Green
    }
}