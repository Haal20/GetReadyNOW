using System;

namespace src
{
    // Ett reaktionsspel
    class Game
    {
        // X - tiden i millisecunder innan NOW skrivs ut.
        private int sleepTime;
        // Tickcount när vi börjar vänta.
        private int sleepTick;
        // Y - tickcount när NOW skrivs ut.
        private int startTick;
        // Z - tickcount när användaren trycker på skärmen.
        private int endTick;

        // Resultatet av spelet.
        private int results;


        public int Results
        {
            get
            {
                return results;
            }
        }

        public Game()
        {
            Random random = new Random();
            sleepTime = 1000 * random.Next(3, 6);
        }

        public void StartGame()
        {
            Console.WriteLine("OK, get ready...");
            sleepTick = System.Environment.TickCount;
            int endTick = sleepTick + sleepTime;

            // Under väntetiden...
            while (System.Environment.TickCount < endTick)
            {
                if (Console.KeyAvailable)
                {
                    EndGame(true);
                    return;
                }
            }

            // Kör nu!
            Console.WriteLine("NOW!!!");
            startTick = System.Environment.TickCount;
            while (true)
            {
                if (Console.KeyAvailable)
                {
                    EndGame(false);
                    return;
                }
            }
        }

        private void EndGame(bool didCheat)
        {
            if (didCheat)
            {
                results = 1000000;
                Console.WriteLine("Du fuskade! skäms!");
            }
            else
            {
                endTick = System.Environment.TickCount;
                results = endTick - startTick;
                Console.WriteLine("Reaktionstiden i millisecunder var: " + results);
            }
        }
    }
}
