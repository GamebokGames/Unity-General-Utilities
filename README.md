<h1 align="center">Gamebok Unity General Utilities</h1>
<p align="center">
  <img src="https://www.gamebok.co.za/wp-content/uploads/2023/12/GamebokLogo@2x-150x150.png">
</p>

## Installation

1. Navigate to ```Window/Package Manager```
2. Click the plus icon 
2. Click "Install package from git url"
4. Paste ```https://github.com/GamebokGames/Unity-General-Utilities.git```

## Contributing
1. Clone in a **new** or **exisiting** Unity Project
2. Modify
3. **Push changes** or create a **pull request**

## Features

### Editor

#### Menu Item Shortcuts
Find them under **Gamebok/Utility/Open**

* Open [Persistent Data Path](https://docs.unity3d.com/ScriptReference/Application-persistentDataPath.html)
* Open Terminal (MacOS, Windows Terminal, CMD etc)

#### Context Menu Shortcuts
* Open File/Folder in VSCode

### Runtime

#### Proxy

Alternative to **Singletons**. Very useful for calling methods in **unity events**. Supports **polymorphism**.

1. Create your Proxy

```cs
[CreateAssetMenu(fileName = "MultiplayerManagerProxy", menuName = "ScriptableObjects/MultiplayerManagerProxy", order = 1)]
public class MultiplayerManagerProxy : Proxy<IMultiplayerManager>, IMultiplayerManager
{
    public void CreateSession()
    {
        Value.CreateSession();
    }

    public void EndSession()
    {
        Value.EndSession();
    }

    public void JoinSession(string code)
    {
        Value.JoinSession(code);
    }
}
```

2. Register your Instance

```cs
public class MultiplayerManager : MonoSingleton<IMultiplayerManager> IMultiplayerManager 
{
    [SerializedField] private MultiplayerManagerProxy proxy;
    
    public void Awake()
    {
       proxy.Register(this)
    }
}
```

#### Variable&lt;T&gt;

A **generic** variable. Useful for **callbacks**.

```cs
public class Player : Monobehaviour 
{
    public Variable<float> Health;

    public void TakeDamage()
    {
        health.SetValue(health.Value - 10f)
    }
}

public class PlayerHealthBar : Monobehaviour 
{
    public Player player;

    public void Start()
    {
        player.Health.Changed += OnHealthUpdated;
    }

    void OnHealthUpdated(float val)
    {
        healthSlider.Value = 100 / val;
    }
}
```