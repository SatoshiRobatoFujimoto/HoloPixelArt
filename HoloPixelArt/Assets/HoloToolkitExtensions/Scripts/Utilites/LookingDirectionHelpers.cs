using System;
using HoloToolkit.Unity.InputModule;
using HoloToolkit.Unity.SpatialMapping;
using UnityEngine;

namespace HoloToolkitExtensions.Utilies
{
    /// <summary>
    /// Help to calculate the user's head position
    /// </summary>
    public class LookingDirectionHelpers
    {
        // will be reused in different projects
        public static Vector3 GetPositionInLookingDirection(float maxDisance = 2.0f, BaseRayStabilizer stabilizer = null)
        {
            RaycastHit hitInfo;

            var ray = stabilizer != null ? stabilizer.StableRay : new Ray(Camera.main.transform.position, Camera.main.transform.forward);
            // TODO: check if it solves the problems for the drones project.
            if (SpatialMappingManager.Instance != null && Physics.Raycast(ray, out hitInfo, maxDisance, SpatialMappingManager.Instance.LayerMask))
            {
                return hitInfo.point;
            }
            return CalculatePositionDeadAhead(maxDisance);
        }

        public static Vector3 CalculatePositionDeadAhead(float distance = 2.0f, BaseRayStabilizer stabilizer = null)
        {
            return stabilizer != null
                ? stabilizer.StableRay.origin + stabilizer.StableRay.direction.normalized * distance
                : Camera.main.transform.position + Camera.main.transform.forward.normalized * distance;

        }
    }
}
