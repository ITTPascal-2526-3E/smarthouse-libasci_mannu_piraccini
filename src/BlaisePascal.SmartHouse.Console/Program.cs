using System;
using System.Collections.Generic;
// --- Domain ---
using BlaisePascal.SmartHouse.Domain.Appliances;
using BlaisePascal.SmartHouse.Domain.CCTV;
using BlaisePascal.SmartHouse.Domain.CCTV.Repository;
using BlaisePascal.SmartHouse.Domain.Fixutures;
using BlaisePascal.SmartHouse.Domain.Lighting;
using BlaisePascal.SmartHouse.Domain.TemperatureRegulation;
using BlaisePascal.SmartHouse.Domain.Lighting.Repository;
using BlaisePascal.SmartHouse.Domain.Lighting.ValueObjects;
// --- Infrastructure ---
using BlaisePascal.SmartHouse.Infrastructure.Repositories.Devices.Lightning.Lamp.InMemory;
using BlaisePascal.SmartHouse.Infrastructure.Repositories.Devices.CCTV.InMemory;
// --- Application ---
using BlaisePascal.SmartHouse.Application.Devices.Lighting.Lamp.Commands;
using BlaisePascal.SmartHouse.Application.Devices.Lighting.Lamp.Queries;
using BlaisePascal.SmartHouse.Application.Devices.CCTV.Commands;
using BlaisePascal.SmartHouse.Application.Devices.CCTV.Queries;


namespace BlaisePascal.SmartHouse.ConsoleApp
{
    public class Program
    {
        static ILampRepository lampRepo = new InMemoryLampRepository();
        static ICCTVRepository cctvRepo = new InMemoryCCTVRepository();

        static CoffeeMachine macchinetta;
        static Door portaPrincipale;
        static AirConditioner clima;

        static void Main(string[] args)
        {
            InizializzaCasa();

            bool chiudiApp = false;

            while (!chiudiApp)
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine("╔════════════════════════════════════════╗");
                Console.WriteLine("║        SMART HOUSE - PANNELLO LIVE     ║");
                Console.WriteLine("╚════════════════════════════════════════╝");
                Console.ResetColor();
                Console.WriteLine("Seleziona COSA vuoi gestire (numero):");
                Console.WriteLine("[1] Macchina del Caffè");
                Console.WriteLine("[2] Telecamere di Sicurezza (CQRS: Commands & Queries)");
                Console.WriteLine("[3] Porta d'Ingresso");
                Console.WriteLine("[4] Climatizzatore");
                Console.WriteLine("[5] Illuminazione (CQRS: Commands & Queries)");
                Console.WriteLine("[0] ESCI");
                Console.WriteLine("----------------------------------------------");
                Console.Write("Scelta: ");

                string sceltaPrincipale = Console.ReadLine() ?? string.Empty;

                switch (sceltaPrincipale)
                {
                    case "1": GestisciCaffe(macchinetta); break;
                    case "2": MenuCCTV(); break;
                    case "3": GestisciPorta(portaPrincipale); break;
                    case "4": GestisciClima(clima); break;
                    case "5": MenuIlluminazione(); break;
                    case "0": chiudiApp = true; break;
                    default:
                        Console.WriteLine("Scelta non valida. Premi un tasto.");
                        Console.ReadKey();
                        break;
                }
            }
        }

        static void InizializzaCasa()
        {
            macchinetta = new CoffeeMachine();
            portaPrincipale = new Door();
            clima = new AirConditioner("Dyson", 1500);
        }

        // SOTTOMENU CQRS PER ILLUMINAZIONE

        static void MenuIlluminazione()
        {
            bool tornaIndietro = false;
            while (!tornaIndietro)
            {
                Console.Clear();
                Console.WriteLine("--- GESTIONE ILLUMINAZIONE (CQRS) ---");

                var getAllQuery = new GetAllLampsQuery(lampRepo);
                var lamps = getAllQuery.Execute();

                Console.WriteLine($"\nTotale lampade trovate: {lamps.Count}");
                foreach (var l in lamps)
                {
                    Console.WriteLine($"- ID: {l.id_lamp} | Brand: {l.brand?.Name ?? "Generico"} | Stato: {(l.IsOn ? "ON" : "OFF")} | Lum: {l.current_brightness_percentage}%");
                }

                Console.WriteLine("\n[A] Aggiungi Nuova Lampada");
                Console.WriteLine("[B] Rimuovi Lampada");
                Console.WriteLine("[C] Gestisci Lampada Specifica");
                Console.WriteLine("[R] Torna al Menu Principale");
                Console.Write("\nAzione: ");

                string azione = Console.ReadLine()?.ToUpper() ?? "";

                try
                {
                    if (azione == "A")
                    {
                        Console.Write("\nInserisci il Brand della nuova lampada: ");
                        string nuovoBrand = Console.ReadLine() ?? "Generico";

                        if (string.IsNullOrWhiteSpace(nuovoBrand)) nuovoBrand = "Generico";

                        var addCommand = new AddLampCommand(lampRepo);
                        addCommand.Execute(nuovoBrand, "LED", 10.0, 1050, true, "E27");

                        Console.WriteLine("Fatto! Premi un tasto.");
                        Console.ReadKey();
                    }
                    else if (azione == "B")
                    {
                        Console.Write("Inserisci l'ID esatto della lampada da rimuovere: ");
                        if (Guid.TryParse(Console.ReadLine(), out Guid idToRemove))
                        {
                            var removeCommand = new RemoveLampCommand(lampRepo);
                            removeCommand.Execute(idToRemove);
                            Console.WriteLine("Comando eseguito. Premi un tasto.");
                        }
                        else MostraErrore("Formato ID non valido.");
                        Console.ReadKey();
                    }
                    else if (azione == "C")
                    {
                        Console.Write("Inserisci l'ID della lampada da gestire: ");
                        if (Guid.TryParse(Console.ReadLine(), out Guid idToManage))
                        {
                            GestisciLuce(idToManage);
                        }
                        else MostraErrore("Formato ID non valido.");
                    }
                    else if (azione == "R") tornaIndietro = true;
                }
                catch (Exception ex) { MostraErrore(ex.Message); }
            }
        }

        static void GestisciLuce(Guid lampId)
        {
            bool torna = false;
            while (!torna)
            {
                try
                {
                    var getByIdQuery = new GetLampByIdQuery(lampRepo);
                    var lamp = getByIdQuery.Execute(lampId);

                    Console.Clear();
                    Console.WriteLine($"--- GESTIONE LAMPADA ---");
                    Console.WriteLine($"ID: {lamp.id_lamp}");
                    Console.WriteLine($"Brand: {lamp.brand?.Name ?? "Generico"} | Tipo: {lamp.TypeOfLamp}");
                    Console.WriteLine($"Stato: {(lamp.IsOn ? "ACCESA" : "SPENTA")} | Luminosità: {lamp.current_brightness_percentage}%");
                    Console.WriteLine("\n[A] Accendi | [B] Spegni | [C] Cambia Intensità (Dimmer) | [R] Esci");
                    Console.Write("Azione: ");

                    string azione = Console.ReadLine()?.ToUpper() ?? "";

                    if (azione == "A") new SwitchLampOnCommand(lampRepo).Execute(lampId);
                    else if (azione == "B") new SwitchLampOffCommand(lampRepo).Execute(lampId);
                    else if (azione == "C")
                    {
                        Console.Write("Nuova intensità % (1-100): ");
                        if (double.TryParse(Console.ReadLine(), out double livello))
                        {
                            new ChangeIntensityCommand(lampRepo).Execute(lampId, livello);
                        }
                    }
                    else if (azione == "R") torna = true;
                }
                catch (Exception ex) { MostraErrore(ex.Message); torna = true; } // Esce se la lampada non esiste
            }
        }

        // SOTTOMENU CQRS PER TELECAMERE (CCTV)
       
        static void MenuCCTV()
        {
            bool tornaIndietro = false;
            while (!tornaIndietro)
            {
                Console.Clear();
                Console.WriteLine("--- GESTIONE TELECAMERE CCTV (CQRS) ---");

                var getAllQuery = new GetAllCCTVsQuery(cctvRepo);
                var cctvs = getAllQuery.Execute();

                Console.WriteLine($"\nTotale telecamere trovate: {cctvs.Count}");
                foreach (var c in cctvs)
                {
                    Console.WriteLine($"- ID: {c.Id} | Nome: {c.Name} | Device Status: {c.Status} | Rec Status: {c.CCTVState}");
                }

                Console.WriteLine("\n[A] Aggiungi Nuova Telecamera");
                Console.WriteLine("[B] Rimuovi Telecamera");
                Console.WriteLine("[C] Gestisci Telecamera Specifica");
                Console.WriteLine("[R] Torna al Menu Principale");
                Console.Write("\nAzione: ");

                string azione = Console.ReadLine()?.ToUpper() ?? "";

                try
                {
                    if (azione == "A")
                    {
                        Console.Write("\nInserisci il Nome della nuova telecamera (es. Giardino): ");
                        string nuovoNome = Console.ReadLine() ?? "Telecamera Generica";

                        if (string.IsNullOrWhiteSpace(nuovoNome)) nuovoNome = "Telecamera Generica";

                        var addCommand = new AddCCTVCommand(cctvRepo);
                        addCommand.Execute(nuovoNome);

                        Console.WriteLine("Telecamera aggiunta! Premi un tasto.");
                        Console.ReadKey();
                    }
                    else if (azione == "B")
                    {
                        Console.Write("Inserisci l'ID esatto della telecamera da rimuovere: ");
                        if (Guid.TryParse(Console.ReadLine(), out Guid idToRemove))
                        {
                            var removeCommand = new RemoveCCTVCommand(cctvRepo);
                            removeCommand.Execute(idToRemove);
                            Console.WriteLine("Comando eseguito. Premi un tasto.");
                        }
                        else MostraErrore("Formato ID non valido.");
                        Console.ReadKey();
                    }
                    else if (azione == "C")
                    {
                        Console.Write("Inserisci l'ID della telecamera da gestire: ");
                        if (Guid.TryParse(Console.ReadLine(), out Guid idToManage))
                        {
                            GestisciSingolaCCTV(idToManage);
                        }
                        else MostraErrore("Formato ID non valido.");
                    }
                    else if (azione == "R") tornaIndietro = true;
                }
                catch (Exception ex) { MostraErrore(ex.Message); }
            }
        }

        static void GestisciSingolaCCTV(Guid cctvId)
        {
            bool torna = false;
            while (!torna)
            {
                try
                {
                    var getByIdQuery = new GetCCTVByIDQuery(cctvRepo);
                    var cctv = getByIdQuery.Execute(cctvId);

                    Console.Clear();
                    Console.WriteLine($"--- GESTIONE TELECAMERA ---");
                    Console.WriteLine($"ID: {cctv.Id}");
                    Console.WriteLine($"Nome: {cctv.Name}");
                    Console.WriteLine($"Stato Dispositivo: {cctv.Status} | Stato Registrazione: {cctv.CCTVState}");

                    Console.WriteLine("\n[A] Vai Online (Accendi) | [B] Vai Offline (Spegni)");
                    Console.WriteLine("[C] Inizia Registrazione | [D] Ferma Registrazione");
                    Console.WriteLine("[E] Simula Errore        | [R] Esci");
                    Console.Write("Azione: ");

                    string azione = Console.ReadLine()?.ToUpper() ?? "";

                    if (azione == "A") new SwitchOnCCTVCommand(cctvRepo).Execute(cctvId);
                    else if (azione == "B") new SwitchOffCCTVCommand(cctvRepo).Execute(cctvId);
                    else if (azione == "C") new StartRecordingCCTVCommand(cctvRepo).Execute(cctvId);
                    else if (azione == "D") new StopRecordingCCTVCommand(cctvRepo).Execute(cctvId);
                    else if (azione == "E") new SetErrorCCTVCommand(cctvRepo).Execute(cctvId);
                    else if (azione == "R") torna = true;
                }
                catch (Exception ex) { MostraErrore(ex.Message); torna = true; } // Esce se la cctv viene rimossa o non trovata
            }
        }

        // GESTIONE DISPOSITIVI STANDARD

        static void GestisciCaffe(CoffeeMachine m)
        {
            bool tornaIndietro = false;
            while (!tornaIndietro)
            {
                Console.Clear();
                Console.WriteLine("--- GESTIONE MACCHINA CAFFÈ ---");
                Console.WriteLine($"Stato: {(m.IsOn ? "ACCESA" : "SPENTA")} | Acqua: {m.WaterLevel}%");
                Console.WriteLine("\n[A] Accendi/Spegni | [B] +Acqua | [C] Tazza | [D] Caffè | [R] Esci");
                Console.Write("\nAzione: ");
                string azione = Console.ReadLine()?.ToUpper() ?? "";
                try
                {
                    if (azione == "A") m.TurnOnOrOff();
                    else if (azione == "B") m.AddWater(20);
                    else if (azione == "C") m.PlaceCup();
                    else if (azione == "D") { m.MakeCoffee(); Console.WriteLine("Fatto!"); Console.ReadKey(); }
                    else if (azione == "R") tornaIndietro = true;
                }
                catch (Exception ex) { MostraErrore(ex.Message); }
            }
        }

        static void GestisciPorta(Door d)
        {
            bool torna = false;
            while (!torna)
            {
                Console.Clear();
                Console.WriteLine($"--- PORTA --- Aperta: {d.isOpen} | Bloccata: {d.isLocked}");
                Console.WriteLine("[A] Apri/Chiudi | [B] Lock/Unlock | [R] Esci");
                string azione = Console.ReadLine()?.ToUpper() ?? "";
                try
                {
                    if (azione == "A") d.OpenOrClose();
                    else if (azione == "B") d.LockOrUnlock();
                    else if (azione == "R") torna = true;
                }
                catch (Exception ex) { MostraErrore(ex.Message); }
            }
        }

        static void GestisciClima(AirConditioner ac)
        {
            bool torna = false;
            while (!torna)
            {
                Console.Clear();
                Console.WriteLine($"--- CLIMA {ac.Brand} --- Temp: {ac.TargetTemperature}°");
                Console.WriteLine("[A] On/Off | [B] Imposta Temp | [R] Esci");
                string azione = Console.ReadLine()?.ToUpper() ?? "";
                try
                {
                    if (azione == "A") ac.TurnOnOrOff();
                    else if (azione == "B") { Console.Write("Gradi: "); ac.SetTemperature(double.Parse(Console.ReadLine() ?? "20")); }
                    else if (azione == "R") torna = true;
                }
                catch (Exception ex) { MostraErrore(ex.Message); }
            }
        }

        static void MostraErrore(string msg)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"\n[ERRORE]: {msg}");
            Console.ResetColor();
            Console.ReadKey();
        }
    }
}