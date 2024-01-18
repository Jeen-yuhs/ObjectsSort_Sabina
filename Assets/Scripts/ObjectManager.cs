using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectManager : MonoBehaviour
{
    public int _numberOfCubes;
    [SerializeField] private int _cubeHeightMax;
    [SerializeField] private GameObject[] _cubes;

    public void StartSort()
    {
        IntializeRandom();
        StartCoroutine(SelectionSort(_cubes));

    }

    IEnumerator SelectionSort(GameObject[] unsortedList)
    {
        int min;
        GameObject temp;
        Vector3 tempPosition;

        for (int i = 0; i < unsortedList.Length; i++)
        {
            min = i;
            yield return new WaitForSeconds(1);

            for (int j = i + 1; j < unsortedList.Length; j++)
            {
                if (unsortedList[j].transform.localScale.y < unsortedList[min].transform.localScale.y)
                {
                    min = j;
                }
            }

            if (min != i)
            {
                temp = unsortedList[i];
                unsortedList[i] = unsortedList[min];
                unsortedList[min] = temp;

                tempPosition = unsortedList[i].transform.localPosition;

                unsortedList[i].transform.localPosition = new Vector3(unsortedList[min].transform.localPosition.x, tempPosition.y, tempPosition.z);

                unsortedList[min].transform.localPosition = new Vector3(tempPosition.x, unsortedList[min].transform.localPosition.y, unsortedList[min].transform.localPosition.z);
            }
        }
    }

    void IntializeRandom()
    {
        _cubes = new GameObject[_numberOfCubes];

        for (int i = 0; i < _numberOfCubes; i++)
        {
            int randomNumber = Random.Range(1, _cubeHeightMax + 1);

            GameObject cube = GameObject.CreatePrimitive(PrimitiveType.Cube);
            cube.transform.localScale = new Vector3(x: 0.9f, y: randomNumber, z: 1);
            cube.transform.position = new Vector3(x: i, y: randomNumber / 2.0f, z: 0);

            cube.transform.parent = this.transform;

            _cubes[i] = cube;
        }
    }

}
   