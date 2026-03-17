using System;
using System.Collections.Generic;
using System.Linq;
// Domain 
using BlaisePascal.SmartHouse.Domain.Appliances;
using BlaisePascal.SmartHouse.Domain.CCTV;
using BlaisePascal.SmartHouse.Domain.Fixutures;
using BlaisePascal.SmartHouse.Domain.Lighting;
using BlaisePascal.SmartHouse.Domain.TemperatureRegulation;
using BlaisePascal.SmartHouse.Domain.Lighting.ValueObjects;
using BlaisePascal.SmartHouse.Domain.Lighting.Repository;
// Infrastructure
using BlaisePascal.SmartHouse.Infrastructure.Repositories.Devices.Lightning.Lamp.InMemory;
// Application
using BlaisePascal.SmartHouse.Application.Devices.Lighting.Lamp.Commands;
using BlaisePascal.SmartHouse.Application.Devices.Lighting.Lamp.Queries;

namespace BlaisePascal.SmartHouse.ConsoleApp
{
    public enum _Brand { Samsung, Philips, Nespresso, Dyson, Generic }

    public class Program
    {
        // --- REPOSITORY ---
        static ILampRepository lampRepo = new InMemoryLampRepository();

        // --- DISPOSITIVI STANDARD ---
        static CoffeeMachine macchinetta;
        static CCTV telecamera;
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
                Console.WriteLine("[2] Telecamera di Sicurezza");
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
                    case "2": GestisciCCTV(telecamera); break;
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
            telecamera = new CCTV("Ingresso");
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
                    Console.WriteLine($"- ID: {l.id_lamp} | Brand: {l.brand} | Stato: {(l.IsOn ? "ON" : "OFF")} | Lum: {l.current_brightness_percentage}%");
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
                        Console.WriteLine("\nAggiunta lampada 'Osram' in corso...");

                        var addCommand = new AddLampCommand(lampRepo);
                        addCommand.Execute("Osram", "LED", 10.0, 1050, true, "E27");

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
                        else
                        {
                            MostraErrore("Formato ID non valido.");
                        }
                        Console.ReadKey();
                    }
                    else if (azione == "C")
                    {
                        Console.Write("Inserisci l'ID della lampada da gestire: ");
                        if (Guid.TryParse(Console.ReadLine(), out Guid idToManage))
                        {
                            GestisciLuce(idToManage);
                        }
                    }
                    else if (azione == "R")
                    {
                        tornaIndietro = true;
                    }
                }
                catch (Exception ex)
                {
                    MostraErrore(ex.Message);
                }
            }
        }

        // GESTIONE SINGOLA LAMPADA (Tramite CQRS)
        static void GestisciLuce(Guid lampId)
        {
            bool torna = false;
            while (!torna)
            {
                try
                {
                    // ESECUZIONE QUERY: Recupero stato aggiornato 
                    var getByIdQuery = new GetLampByIdQuery(lampRepo);
                    var lamp = getByIdQuery.Execute(lampId);

                    Console.Clear();
                    Console.WriteLine($"--- GESTIONE LAMPADA ---");
                    Console.WriteLine($"ID: {lamp.id_lamp}");
                    Console.WriteLine($"Brand: {lamp.brand} | Tipo: {lamp.TypeOfLamp}");
                    Console.WriteLine($"Stato: {(lamp.IsOn ? "ACCESA" : "SPENTA")} | Luminosità: {lamp.current_brightness_percentage}%");
                    Console.WriteLine("\n[A] Accendi | [B] Spegni | [C] Cambia Intensità (Dimmer) | [R] Esci");
                    Console.Write("Azione: ");

                    string azione = Console.ReadLine()?.ToUpper() ?? "";

                    // ESECUZIONE COMMANDS in base alla scelta 
                    if (azione == "A")
                    {
                        new SwitchLampOnCommand(lampRepo).Execute(lampId);
                    }
                    else if (azione == "B")
                    {
                        new SwitchLampOffCommand(lampRepo).Execute(lampId);
                    }
                    else if (azione == "C")
                    {
                        Console.Write("Nuova intensità % (1-100): ");
                        if (double.TryParse(Console.ReadLine(), out double livello))
                        {
                            new ChangeIntensityCommand(lampRepo).Execute(lampId, livello);
                        }
                    }
                    else if (azione == "R")
                    {
                        torna = true;
                    }
                }
                catch (Exception ex)
                {
                    MostraErrore(ex.Message);
                }
            }
        }

       
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

        static void GestisciCCTV(CCTV c)
        {
            bool torna = false;
            while (!torna)
            {
                Console.Clear();
                Console.WriteLine($"--- CCTV: {c.Name} --- Status: {c.Status}");
                Console.WriteLine("[A] On/Off | [B] Rec | [C] Stop | [R] Esci");
                string azione = Console.ReadLine()?.ToUpper() ?? "";
                if (azione == "A") c.TurnOnOrOff();
                else if (azione == "B") c.StartRecording();
                else if (azione == "C") c.StopRecording();
                else if (azione == "R") torna = true;
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
                    else if (azione == "B") { Console.Write("Gradi: "); ac.SetTemperature(double.Parse(Console.ReadLine())); }
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