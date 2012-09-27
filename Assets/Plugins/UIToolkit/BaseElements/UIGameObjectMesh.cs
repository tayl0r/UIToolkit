using UnityEngine;
using System.Collections.Generic;

/**
 * UIGameObjectMesh
 * for displaying a game object that has a Mesh Renderer component in your UI
 * 
 */
public class UIGameObjectMesh : UIObject, IPositionable
{
	public bool gameObjectOriginInCenter = false;  // Set to true to get your origin in the center.  Useful for scaling/rotating
	
	public static UIGameObjectMesh create( GameObject prefabMesh, int xPos, int yPos, int depth )
	{
		return new UIGameObjectMesh(prefabMesh, new Vector2(xPos, yPos), depth);
	}
	
	public UIGameObjectMesh( GameObject prefabMesh, Vector2 pos, int depth ) : this( prefabMesh, pos, depth, false )
	{}
	
    public UIGameObjectMesh( GameObject prefabMesh, Vector2 pos, int depth, bool gameObjectOriginInCenter ) : base( prefabMesh )
    {
		this.gameObjectOriginInCenter = gameObjectOriginInCenter;
        if( gameObjectOriginInCenter )
        {
            _anchorInfo.OriginUIxAnchor = UIxAnchor.Center;
            _anchorInfo.OriginUIyAnchor = UIyAnchor.Center;
        }
		
		// Setup our GO
		clientTransform.position = new Vector3( pos.x, -pos.y, depth ); // Depth will affect z-index
		
		Vector3 meshSize = client.gameObject.renderer.bounds.size;
		_width = meshSize.x;
		_height = meshSize.y;
		
		// Save these for later.  The manager will call initializeSize() when the UV's get setup
		//_width = frame.width;
		//_height = frame.height;
		
		//_uvFrame = uvFrame;
    }
	
	// Width and Height of the sprite in worldspace units.
    public new float width { get { return _width * scale.x; } }
    public new float height { get { return _height * scale.y; } }

}
