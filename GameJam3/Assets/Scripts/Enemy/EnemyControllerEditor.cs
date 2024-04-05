// using UnityEditor;
// using UnityEngine;

// // [CustomEditor(typeof(EnemyController))]
// public class EnemyControllerEditor : Editor
// {
//     private void OnSceneGUI()
//     {
//         EnemyController fov = (EnemyController)target;
//         Handles.color = Color.white;
//         Handles.DrawWireArc(fov.transform.position, Vector3.up, Vector3.forward, 360, fov.radius);

//         Vector3 viewAngle01 = DirectionFromAngle(fov.transform.eulerAngles.y, -fov.visionRange / 2) ;
//         Vector3 viewAngle02 = DirectionFromAngle(fov.transform.eulerAngles.y, fov.visionRange / 2);

//         Handles.color = Color.yellow;
//         Handles.DrawLine(fov.transform.position, fov.transform.position + viewAngle01 * fov.radius);
//         Handles.DrawLine(fov.transform.position, fov.transform.position + viewAngle02 * fov.radius);

//         if (fov.hasLineOfSight)
//         {
//             Handles.color = Color.green;
//             Handles.DrawLine(fov.transform.position, fov.target.transform.position);
//         }
//     }

//     private Vector3 DirectionFromAngle(float eulerY, float angleInDegrees)
//     {
//         angleInDegrees += eulerY;

//         return new Vector3(Mathf.Sin(angleInDegrees * Mathf.Deg2Rad), 0, Mathf.Cos(angleInDegrees * Mathf.Deg2Rad));
//     }
// }
