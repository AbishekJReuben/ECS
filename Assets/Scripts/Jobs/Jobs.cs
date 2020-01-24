using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Jobs;
using Unity.Collections;
using Unity.Burst;

public class Jobs : MonoBehaviour
{
    [SerializeField] bool usingJobs;

    private void Update()
    {
        if (usingJobs)
        {
            NativeList<JobHandle> jobHandles = new NativeList<JobHandle>(Allocator.Temp);
            for (int i = 0; i < 100; i++)
            {
                JobHandle jobHandle = ReallyToughTaskJob();
                jobHandles.Add(jobHandle);
            }
            JobHandle.CompleteAll(jobHandles);
            jobHandles.Dispose();
        }
        else
        {
            for (int i = 0; i < 100; i++)
            {
                ReallyToughTask();
            }
        }
    }

    void ReallyToughTask()
    {
        float something;
        for (int i = 0; i < 10000; i++)
        {
            something = Mathf.Sqrt(1235342);
        }
    }

    JobHandle ReallyToughTaskJob()
    {
        ReallyToughJob reallyToughJob = new ReallyToughJob();
        return reallyToughJob.Schedule();
    }

    [BurstCompile]
    public struct ReallyToughJob : IJob
    {
        public void Execute()
        {
            float something;

            for (int i = 0; i < 10000; i++)
            {
                something = Mathf.Sqrt(1235342);
            }
        }
    }
}
