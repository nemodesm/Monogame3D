using System;
using System.Diagnostics;
using VillageDefender;

try
{
    Console.WriteLine("====================================================================");
    Console.WriteLine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData));
    Console.WriteLine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData));
    Console.WriteLine("====================================================================");

    using var game = new Game3D();
    game.Run();

    Process.Start(new ProcessStartInfo("explorer.exe",
        $"{Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData)}\\"));
}
catch (Exception ex)
{
#if VISUAL_STUDIO
    Debug.WriteLine(ex);
#else
    Console.Error.WriteLine(ex);
#endif
}