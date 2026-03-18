using System;
using System.Collections.Generic;
using System.Text;
using Framework.Engine;

class Block : GameObject
{
    private bool _isDestroyable;

    public Block(Scene scene) : base(scene) { }

    public override void Draw(ScreenBuffer buffer)
    {
    }

    public override void Update(float deltaTime)
    {
    }
}