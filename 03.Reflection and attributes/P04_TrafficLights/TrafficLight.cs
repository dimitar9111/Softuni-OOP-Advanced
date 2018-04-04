namespace P04_TrafficLights
{
    public class TrafficLight
    {
        private Light light;

        public TrafficLight(Light light)
        {
            this.light = light;
        }

        public void ChangeLight()
        {
            this.light++;
            if ((int)light > 2)
            {
                light = 0;
            }
        }

        public override string ToString()
        {
            return light.ToString();
        }
    }
}
