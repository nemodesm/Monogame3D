using System;
using System.Diagnostics;
using VillageDefender;

try
{
    Console.WriteLine("====================================================================");
    Console.WriteLine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData));
    Console.WriteLine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData));
    Console.WriteLine("====================================================================");
    
    Console.WriteLine("\uee00[32m" + "Hello World!\uee00\uee01\uee02\uee03\uee04\uee05\uee06\uee07\uee08\uee09\uee0a\uee0b" + "\uee02[0m");

    using var game = new Game3D();
    game.Run();

    Process.Start($"{Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData)}/");
}
catch (Exception ex)
{
#if VISUAL_STUDIO
    Debug.WriteLine(ex);
#else
    Console.Error.WriteLine(ex);
#endif
}