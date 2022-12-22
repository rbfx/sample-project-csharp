using Urho3DNet;

namespace SampleProject;

class GameScreen : ApplicationState
{
    private SharedPtr<Scene> _scene;

    public GameScreen(Context context) : base(context)
    {
        _scene = Context.CreateObject<Scene>();
        _scene.Ptr.LoadFile("Scenes/Scene.xml");
        SetViewport(0, new Viewport(Context, _scene, _scene.Ptr.GetComponent<Camera>(true)));
    }

    protected override void Dispose(bool disposing)
    {
        _scene.Dispose();
        base.Dispose(disposing);
    }
}