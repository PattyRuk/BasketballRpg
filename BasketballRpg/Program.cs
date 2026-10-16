namespace BasketballRpg
{
    public static class Program
    {
        public static void Main()
        {
            SimulationController controller = new SimulationController();
            controller.RunEngineLoop();
        }
    }
}
