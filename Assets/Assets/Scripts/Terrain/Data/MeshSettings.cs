using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu()]
public class MeshSettings : UpdatableData
{
    public const int numSupportedLODs = 5;
    public const int numSupportedChunkSizes = 9;
    public const int numSupportedFlatshadedChunkSizes = 3;
    public static readonly int[] supportedChunkSizes = {
        48,72,96,120,144,168,192,216,240
    };

    [Range(0,numSupportedChunkSizes-1)]
    public int chunkSizeIndex;
    [Range(0,numSupportedFlatshadedChunkSizes-1)]
    public int flatshadedChunkSizeIndex;

    public float meshScale = 2.5f;
    public bool useFlatShading;

    //num verts per line of mesh rendered at LOD = 0 (inclds 2 extra verts that excld from final mesh, used for calc nomals)
    public int numVerticesPerLine{
        get {
            return supportedChunkSizes[(useFlatShading)?flatshadedChunkSizeIndex:chunkSizeIndex] + 1;
        }
    }

    public float meshWorldSize {
        get {
            return (numVerticesPerLine - 3) * meshScale;
        }
    }

    
}
