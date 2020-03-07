using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
namespace Assets.Scripts
{
#if UNITY_EDITOR
    using UnityEditor;
    using UnityEditor.UIElements;
#endif
    public class DamageAbility : MonoBehaviour
    {
        public float DamageDealt;
        public float Delay;

        [HideInInspector] public bool DamageOverTime;
        [HideInInspector] public float Interval;
        [HideInInspector] public float ApplyEveryNSeconds;

        private int appliedTimes = 0;

        void Start()
        {
            StartCoroutine(DPS());
        }

        public IEnumerator DPS()
        {
            yield return new WaitForSeconds(Delay);

            if (!DamageOverTime) Interval = 1;

            while (appliedTimes < Interval)
            {
                gameObject.GetComponent<Health>().ReduceHealth(DamageDealt);
                yield return new WaitForSeconds(ApplyEveryNSeconds);
                appliedTimes++;
            }

            Destroy(this);
        }
    }

#if UNITY_EDITOR
    [CustomEditor(typeof(DamageAbility))]
    public class DamageAbility_Editor : Editor
    {
        public override void OnInspectorGUI()
        {
            DrawDefaultInspector();

            DamageAbility script = (DamageAbility)target;

            script.DamageOverTime = EditorGUILayout.Toggle("Damage over time", script.DamageOverTime);
            if (script.DamageOverTime)
            {
                script.Interval =
                    EditorGUILayout.FloatField("Interval", script.Interval);
                script.ApplyEveryNSeconds =
                    EditorGUILayout.FloatField("Deal damage every X seconds", script.ApplyEveryNSeconds);
            }
        }
    }
#endif
}


