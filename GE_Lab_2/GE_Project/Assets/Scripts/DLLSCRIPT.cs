using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Runtime.InteropServices;

public class DLLSCRIPT : MonoBehaviour
{
    [DllImport("Lab4Thin")]
    public static extern int AddNum(int a, int b);
     [DllImport("Lab4Thin")]
    public static extern int SubNum(int a, int b);
     [DllImport("Lab4Thin")]
    public static extern int MulNum(int a, int b);
     [DllImport("Lab4Thin")]

    public static extern int DivNum(int a, int b);
     [DllImport("Lab4Thin")]

    public static extern void ArrSort(int[] _array, int arrSize);


    // Start is called before the first frame update
    void Start()
    {
        print(AddNum(1,1));
        print(SubNum(1,1));
        print(MulNum(2,2));
        print(DivNum(2,2));
        int[] ravioli = new int[] {8,5,7,3};
        ArrSort(ravioli, ravioli.Length);
        for(int i = 0; i < ravioli.Length; i++){
            print(ravioli[i]);
        }
    }
}
