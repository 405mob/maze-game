using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePlayer : MonoBehaviour
{
  public GameObject path;
  AudioSource audioSource;
  const int rate = 22000;
  const float freq = 440;

    // Start is called before the first frame update
    void Start()
    {
      transform.position = new Vector3(14, 0, 14);
      audioSource = gameObject.AddComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
  	{
      if (Input.GetKeyDown("g"))
      {
        Collider[] intersecting = Physics.OverlapSphere(new Vector3(
        transform.position.x, transform.position.y, transform.position.z + 1), 0.01f);
        if (intersecting.Length == 2)
        {
          transform.position = new Vector3(
          transform.position.x,
          transform.position.y,
          transform.position.z + 1);
          var point = Instantiate<GameObject>(path);
          point.transform.position = new Vector3(
          transform.position.x, transform.position.y+1, transform.position.z - 1);
        } else {
          LoadSine();
          audioSource.PlayDelayed(0.01f);
        }
      }
      if (Input.GetKeyDown("v"))
      {
        Collider[] intersecting = Physics.OverlapSphere(new Vector3(
        transform.position.x - 1, transform.position.y, transform.position.z), 0.01f);
        if (intersecting.Length == 2)
        {
          transform.position = new Vector3(
          transform.position.x - 1,
          transform.position.y,
          transform.position.z);
          var point = Instantiate<GameObject>(path);
          point.transform.position = new Vector3(
          transform.position.x+1, transform.position.y+1, transform.position.z);
        } else {
          LoadTriangle();
          audioSource.PlayDelayed(0.01f);
        }
      }
      if (Input.GetKeyDown("b"))
      {
        Collider[] intersecting = Physics.OverlapSphere(new Vector3(
        transform.position.x, transform.position.y, transform.position.z - 1), 0.01f);
        if (intersecting.Length == 2)
        {
          transform.position = new Vector3(
          transform.position.x,
          transform.position.y,
          transform.position.z - 1);
          var point = Instantiate<GameObject>(path);
          point.transform.position = new Vector3(
          transform.position.x, transform.position.y+1, transform.position.z + 1);
        } else {
          LoadSine();
          audioSource.PlayDelayed(0.01f);
        }
      }
      if (Input.GetKeyDown("n"))
      {
        Collider[] intersecting = Physics.OverlapSphere(new Vector3(
        transform.position.x + 1, transform.position.y, transform.position.z), 0.01f);
        if (intersecting.Length == 2)
        {
          transform.position = new Vector3(
          transform.position.x + 1,
          transform.position.y,
          transform.position.z);
          var point = Instantiate<GameObject>(path);
          point.transform.position = new Vector3(
          transform.position.x - 1, transform.position.y+1, transform.position.z);
        } else {
          LoadTriangle();
          audioSource.PlayDelayed(0.1f);
        }
      }
    }
    void LoadSine()
    {
        float[] data = new float[rate];

        for (int s = 0; s < rate; ++s)
        {
            float phi = (float)s / rate;

            float theta = freq * phi * 2 * Mathf.PI;

            data[s] = Mathf.Sin(theta);
        }

        AudioClip clip = AudioClip.Create("Tone", rate, 1, rate, false);
        clip.SetData(data, 0);

        audioSource.clip = clip;
    }

    void LoadTriangle()
    {
        float[] data = new float[rate];

        for (int s = 0; s < rate; ++s)
        {
            float phi = ((float)s % (rate / freq)) / (rate / freq);

            float signal = 4 * phi - 2;

            if (phi < .25f)
            {
                signal = -4 * phi;
            }
            else if (phi > .75f)
            {
                signal = 4 - 4 * phi;
            }

            data[s] = signal;
        }

        AudioClip clip = AudioClip.Create("Tone", rate, 1, rate, false);
        clip.SetData(data, 0);

        audioSource.clip = clip;
    }
}
