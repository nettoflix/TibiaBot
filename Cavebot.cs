using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FirstForm
{
    public enum DIR
    {
        UP=0, RIGHT, DOWN, LEFT
    }
    struct Step
    {
        public int posX;
        public int posY;
        public DIR direction;
    }
    class Cavebot
    {
     
        IntPtr baseAddress;
        IntPtr processHandle;
        int posBaseAddr = 0x00E17D0C;
        int[] posX_offsets = { 0x18, 0x4, 0xC, 0x18, 0xC, 0x258, 0x34 };
        int[] posY_offsets = { 0x18, 0x4, 0xC, 0x18, 0xC, 0x258, 0x38 };
        private int globalX;
        private int globalY;
        List<Step> steps = new List<Step>();
        public bool running = false;
        private ListBox stepList;
        public Cavebot(IntPtr processHandle, IntPtr baseAddr, ListBox stepList)
        {
            this.baseAddress = baseAddr;
            this.processHandle = processHandle;
            this.stepList = stepList;
        }
        public void updateCords()
        {
           
        }
        public void removeStepAt(int i)
        {
            if (this.stepList.Items.Count == 0) return;
            this.stepList.Items.RemoveAt(i);
            this.steps.RemoveAt(i);
            foreach(Step step in steps)
            {
                Console.WriteLine("X:" + step.posX + " " + "Y:" + step.posY + " Dir:" + step.direction);
            }
        }
        public void addStep(DIR dir)
        {
            Step step = new Step();
            step.direction = dir;
            step.posX = MemoryUtils.ReadMemoryWithOffsets(processHandle,(int)baseAddress + posBaseAddr, posX_offsets);
            step.posY = MemoryUtils.ReadMemoryWithOffsets(processHandle, (int)baseAddress + posBaseAddr, posY_offsets);
            String stepStr = "X:" + step.posX + " " + "Y:" + step.posY + " Dir:" + step.direction;
            stepList.Items.Add(stepStr);
            steps.Add(step);   
            //step.posX = 
        }
        public void caveRun()
        {
            int contando = 0;
            DIR dirToGo=DIR.UP;
           for(int i=0; i<steps.Count; i++)
            
           {
                int posX = MemoryUtils.ReadMemoryWithOffsets(processHandle, (int)baseAddress + posBaseAddr, posX_offsets);
                int posY = MemoryUtils.ReadMemoryWithOffsets(processHandle, (int)baseAddress + posBaseAddr, posY_offsets);
                Step nextStep = steps[i];
          
     
                if (i<steps.Count -1)
                {
                     nextStep = steps[i + 1];
                }
                else
                {
                    //nextStep = steps[0];
                    break;
                }
                Step step = steps[i];
                Console.WriteLine("StepsSize: " + steps.Count);
                Console.WriteLine("posY: " + posY + " posX:" + posX + " DIR:" + step.direction);

                if(step.direction == DIR.UP)
                {
                    if (posY > nextStep.posY)
                    {
                        dirToGo = DIR.UP;
                    }
                }
                else if (step.direction == DIR.DOWN)
                {
                   if(posY< nextStep.posY)
                    {
                       dirToGo= DIR.DOWN;
                    }
                }
                else if (step.direction == DIR.LEFT)
                {
                    if (posX > nextStep.posX)
                    {
                        dirToGo = DIR.LEFT;
                    }
                }
                else if (step.direction == DIR.RIGHT)
                {
                    if (posX < nextStep.posX)
                    {
                        dirToGo = DIR.RIGHT; 
                    }
                }
               
                Console.WriteLine("contado: " + contando);
                contando++;
                bool keepLoop = true;
                while(posX!= nextStep.posX || posY!= nextStep.posY)
                {
                    if(keepLoop)
                    {
                        switch (dirToGo)
                        {
                            case DIR.UP:
                                if (posY < nextStep.posY)
                                {
                                    keepLoop = false;
                                    break;
                                }
                                pressKey(0x148);
                                break;
                            case DIR.RIGHT:
                                if (posX > nextStep.posX)
                                {
                                    keepLoop = false;
                                    break;
                                }
                                pressKey(0x14D);
                                break;
                            case DIR.DOWN:
                                if (posY > nextStep.posY)
                                {
                                    keepLoop = false;
                                    break;
                                }
                                pressKey(0x150);
                                break;
                            case DIR.LEFT:
                                if (posX < nextStep.posX)
                                {
                                    keepLoop = false;
                                    break;
                                }
                                pressKey(0x14B);
                                break;

                        }
                        Thread.Sleep(10);
                        posX = MemoryUtils.ReadMemoryWithOffsets(processHandle, (int)baseAddress + posBaseAddr, posX_offsets);
                        posY = MemoryUtils.ReadMemoryWithOffsets(processHandle, (int)baseAddress + posBaseAddr, posY_offsets);
                    }
                    else
                    {
                        break;
                    }
                 
                }
            }

            running = false;

        }
        public void pressKey(ushort key)
        {
            MemoryUtils.Input[] kb_inputs = new MemoryUtils.Input[]
        {
                new MemoryUtils.Input
                {
                    type = (int)MemoryUtils.InputType.Keyboard,
                    u = new MemoryUtils.InputUnion
                    {
                        ki = new MemoryUtils.KeyboardInput
                        {
                            wVk = 0, //wVk would be the virtual key code but it is being ignore because the Scancode flag is set
                            wScan = key, // arrow up -- that's the hardware key code
                            dwFlags = (uint)(MemoryUtils.KeyEventF.KeyDown | MemoryUtils.KeyEventF.Scancode),
                            dwExtraInfo = MemoryUtils.GetMessageExtraInfo()
                        }
                    }
                },
                new MemoryUtils.Input
                {
                    type = (int)MemoryUtils.InputType.Keyboard,
                    u = new MemoryUtils.InputUnion
                    {
                        ki = new MemoryUtils.KeyboardInput
                        {
                            wVk = 0,
                            wScan = key, // W
                            dwFlags = (uint)(MemoryUtils.KeyEventF.KeyUp | MemoryUtils.KeyEventF.Scancode),
                            dwExtraInfo = MemoryUtils.GetMessageExtraInfo()
                        }
                    }
                }
        };
            MemoryUtils.SendInput((uint)kb_inputs.Length, kb_inputs, Marshal.SizeOf(typeof(MemoryUtils.Input)));
        }
    }
}
