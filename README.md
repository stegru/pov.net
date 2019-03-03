# pov.net

An incomplete .NET Core library that provides the ability to describe and render 3D scenes, using [POV-Ray](http://povray.org).

It's effectively a glorified serialiser, for the POV-Ray DSL.

## Hello World

```c#
Scene scene = new Scene
{
    // Point a camera to the middle of the world.
    Camera = new Camera((2, 1, -7), (0, 1.5, 0)) {FocalPoint = (0, 1.5, 0), BlurSamples = 50}
};

// Add a light.
scene.Add(new LightSource.Area((5, 9, -6))
{
    FadeDistance = 6,
    FadePower = 2
});

// Lay the checkered floor
scene.Add(new Plane(Vector.Y)
{
    Pigment = new Pattern.Checker(Colors.Black, Colors.White),
    Finish = 
    {
        Reflection = 0.02
    }               
});

// Float the mirror ball.
scene.Add(new Sphere((0, 2.5, 0), 2)
{
    Pigment = (0.1, 0.1, 0.1),
    Finish = new Finish
    {
        Reflection =
        {
            ColorMin = 0.9,
            Color = 0.6
        },
        Phong = 1.0,
        PhongSize = 200,
        Diffuse = 0.25
    }
});

// Render it
Povray povray = new Povray();
povray.Render(scene);
```

Produces the following scene file:

```c++
camera {
  location <2, 1, -7>
  look_at <0, 1.5, 0>
  focal_point <0, 1.5, 0>
  blur_samples 50
}

light_source {
  <5, 9, -6>, White
  fade_distance 6
  fade_power 2
  adaptive 0
}

plane {
  y, 0
  texture {
    pigment {
      checker pigment { color Blue },
      
      pigment { color White }
    }
    
    finish { reflection { 0.02 } }
  }
}

sphere {
  <0, 2.5, 0>, 2
  texture {
    pigment { color rgb <0.1, 0.1, 0.1> }
    
    finish {
      diffuse 0.25
      phong 1
      phong_size 200
      reflection {
        0.9,
        0.6
      }
    }
  }
}

```