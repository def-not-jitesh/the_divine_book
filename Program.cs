using System; 
using System.Numerics; 
using Raylib_cs; 
using static Raylib_cs.Raylib;
using Game.Entities; 

class Program {
	static void Main() {
		int ScreenWidth = 1920; 
		int ScreenHeight = 1080; 
		
		SetConfigFlags(ConfigFlags.ResizableWindow); 
		InitWindow(ScreenWidth, ScreenHeight, "The Divine Book"); 

		Texture2D mapText = LoadTexture("Assets/Map/level_1/map.png"); 
		Player player = new Player(); 
		player.loadTexture("Assets/Nightborne/NightBorne.png"); 

		SetTargetFPS(60); 

		while (!WindowShouldClose()) {
			
			float deltaTime = GetFrameTime() * 1000.0f; 
			Console.WriteLine(deltaTime); 

			ScreenWidth = GetScreenWidth(); 
			ScreenHeight = GetScreenHeight(); 

			player.update(deltaTime); 

			BeginDrawing(); 

			ClearBackground(Color.White); 

			DrawTexture(mapText, 0, 0, Color.White); 
			
			player.draw(); 

			EndDrawing(); 	
		}
		
		UnloadTexture(mapText); 
		CloseWindow(); 
	}
}
