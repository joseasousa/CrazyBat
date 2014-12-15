[33mcommit 66fbd786cb4f3571f96741b1a30f8790ae67a7ab[m
Author: Jose Alves <a.sousajose@gmail.com>
Date:   Mon Dec 15 18:15:32 2014 -0300

    trhigger

[1mdiff --git a/Assets/Scene/Main.unity b/Assets/Scene/Main.unity[m
[1mindex f3b44a8..9251072 100644[m
Binary files a/Assets/Scene/Main.unity and b/Assets/Scene/Main.unity differ
[1mdiff --git a/Assets/Scripts/PlayerBehavior.cs b/Assets/Scripts/PlayerBehavior.cs[m
[1mindex 5d2b8e2..bef8f64 100644[m
[1m--- a/Assets/Scripts/PlayerBehavior.cs[m
[1m+++ b/Assets/Scripts/PlayerBehavior.cs[m
[36m@@ -33,6 +33,13 @@[m [mvoid Update()[m
 			gameControler.StartGame();[m
 		}[m
 [m
[32m+[m		[32mVector3 positionPlayer = transform.position;[m
[32m+[m
[32m+[m		[32mif(positionPlayer.y > 5){[m
[32m+[m			[32mpositionPlayer.y = 5;[m
[32m+[m			[32mtransform.position=positionPlayer;[m
[32m+[m		[32m}[m
[32m+[m
 		if(gameControler.getCurentState() != GameStates.INGAME && [m
 		   gameControler.getCurentState() != GameStates.GAMEOVER)[m
 		{[m
[36m@@ -58,7 +65,7 @@[m [mvoid Update()[m
 		gameControler.CallGameOver();		[m
 	}[m
 [m
[31m-	void OnTriggerEnter2d(Collision2D coll) {[m
[32m+[m	[32mvoid OnTriggerEnter2D(Collider2D coll) {[m
 		gameControler.CallGameOver();		[m
 	}[m
 [m
[1mdiff --git a/Library/ScriptAssemblies/Assembly-CSharp.dll b/Library/ScriptAssemblies/Assembly-CSharp.dll[m
[1mindex ae4660a..3473d83 100644[m
Binary files a/Library/ScriptAssemblies/Assembly-CSharp.dll and b/Library/ScriptAssemblies/Assembly-CSharp.dll differ
[1mdiff --git a/Library/ScriptAssemblies/Assembly-CSharp.dll.mdb b/Library/ScriptAssemblies/Assembly-CSharp.dll.mdb[m
[1mindex 97709e6..a41d047 100644[m
Binary files a/Library/ScriptAssemblies/Assembly-CSharp.dll.mdb and b/Library/ScriptAssemblies/Assembly-CSharp.dll.mdb differ
[1mdiff --git a/Library/assetDatabase3 b/Library/assetDatabase3[m
[1mindex 794003e..00cc757 100644[m
Binary files a/Library/assetDatabase3 and b/Library/assetDatabase3 differ
[1mdiff --git a/Library/metadata/4b/4be0dd6a5923b504495cd92d77f629e7 b/Library/metadata/4b/4be0dd6a5923b504495cd92d77f629e7[m
[1mindex 739ff91..8d61189 100644[m
Binary files a/Library/metadata/4b/4be0dd6a5923b504495cd92d77f629e7 and b/Library/metadata/4b/4be0dd6a5923b504495cd92d77f629e7 differ
