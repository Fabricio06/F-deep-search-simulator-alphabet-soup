namespace GUI;
using System;
using GenerarSopaLetras;
using BusquedaProfu;

static class Program
{
    private static GenerarSopaLetras.Program sopaLetras = new GenerarSopaLetras.Program(); //La instancia con el proyecto GenerarSopaLetras

    /// <summary>
    ///  The main entry point for the application.
    /// </summary>
    [STAThread]
    static void Main()
    {
        // To customize application configuration such as set high DPI settings or default font,
        // see https://aka.ms/applicationconfiguration.
        ApplicationConfiguration.Initialize();
        Application.Run(new Principal(sopaLetras));
    }
}