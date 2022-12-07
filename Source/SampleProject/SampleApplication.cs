using Urho3DNet;

namespace SampleProject;

class SampleApplication : Application
{
    private Scene _scene;

    public SampleApplication(Context context) : base(context)
    {
    }

    public override void Setup()
    {
        base.Setup();
    }

    public override void Start()
    {
        base.Start();

        _scene = Context.CreateObject<Scene>();
        _scene.AddRef();
        _scene.LoadFile("Scenes/Scene.xml");
        Context.Renderer.SetViewport(0, new Viewport(Context, _scene, _scene.GetComponent<Camera>(true)));
    }

    public override void Stop()
    {
        _scene.ReleaseRef();
        base.Stop();
    }
}