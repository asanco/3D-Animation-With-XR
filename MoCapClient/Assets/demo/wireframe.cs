using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class wireframe : MonoBehaviour
{
    public GoogleARCore.Examples.AugmentedFaces.ARCoreAugmentedFaceMeshFilter _source;

    private Mesh _face;
    private Mesh _mesh;
    private Vector3[] _vertices;
    public Text vertixPos;
    public int mouthDistance = 0;
    public Slider slider;

    // Start is called before the first frame update
    void Start()
    {
        _face = _source.GetComponent<MeshFilter>().mesh;
        _mesh = GetComponent<MeshFilter>().mesh;
        int count = _mesh.triangles.Length;
        _vertices = new Vector3[count];

        _vertices = new Vector3[count];
        var _wireframe_indices = new int[count];
        var _wireframe_uvs = new Vector2[count];
        for (var i = 0; i < count; i += 3)
        {
            _wireframe_indices[i] = i;
            _wireframe_indices[i + 1] = i + 1;
            _wireframe_indices[i + 2] = i + 2;
            _wireframe_uvs[i] = new Vector2(0f, 0f);
            _wireframe_uvs[i + 1] = new Vector2(1f, 0f);
            _wireframe_uvs[i + 2] = new Vector2(0f, 1f);
        }
        _mesh.Clear();
        _mesh.vertices = _vertices;
        _mesh.uv = _wireframe_uvs;
        _mesh.triangles = _wireframe_indices;
        _mesh.RecalculateBounds();
    }

    // Update is called once per frame
    void Update()
    {
        var tri = _face.triangles;
        var vtx = _face.vertices;
        for (int i = 0; i < tri.Length; i += 3)
        {
            int i0 = tri[i];
            int i1 = tri[i + 1];
            int i2 = tri[i + 2];
            _vertices[i] = vtx[i0];
            _vertices[i + 1] = vtx[i1];
            _vertices[i + 2] = vtx[i2];
        }

        _mesh.vertices = _vertices;
        _mesh.RecalculateBounds();

        vertixPos.text = "Distance: " + Vector3.Distance(_mesh.vertices[15], _mesh.vertices[0]);

        mouthDistance =(int) ((Vector3.Distance(_mesh.vertices[15], _mesh.vertices[0]) - 0.068f)/(0.076f-0.068f) * 100);
        Debug.Log(mouthDistance);
        if(mouthDistance>-20 && mouthDistance < 120) {
            slider.value = mouthDistance;
        }
    }

    public void CreateSpheres()
    {
        var vtx = _face.vertices;
        var finalText = "";

        for (int i = 0; i < vtx.Length; i++)
        {
            finalText = vtx[i].x.ToString("F4") + " , " + vtx[i].y.ToString("F4") + " , " + vtx[i].z.ToString("F4");
            Debug.Log(finalText);

        }
    }
}
