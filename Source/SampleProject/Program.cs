using Urho3DNet;

namespace SampleProject
{
    static class Program
    {
        public static void Main(string[] args)
        {

            using (var context = new Context())
            {
                using (var app = new SampleApplication(context))
                {
                    app.Run();
                }
            }
        }
    }
}