using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MTConnect;

namespace LuNanAdapterSDK
{
    public class LuNanAdapter
    {
        //适配器
        private Adapter mAdapter;

        //端口号
        private int mPort=7878;
        
        //数据项
        //可用性
        private Event mAvail;
        
        //急停
        private Event mEStop;

        //控制器模式
        private Event mControllerMode;

        //系统状态
        private Condition mSystemStatus;

        //系统消息
        private Event mSystemMessage;

        //程序执行状态
        private Event mExecution;

        //程序名
        private Event mProgram;

        //主轴转速
        private Sample mSpindleRotaryVelocity;

        //主轴负载
        private Sample mSpindleLoad;

        //进给速度
        private Sample mPathFeedrate;

        //进给轴
        //X轴信息,位置,速度,负载
        private Sample mXPos;
        private Sample mXAxisFeedrate;
        private Sample mXLoad;

        //Y轴
        private Sample mYPos;
        private Sample mYAxisFeedrate;
        private Sample mYLoad;

        //Z
        private Sample mZPos;
        private Sample mZAxisFeedrate;
        private Sample mZLoad;

        //A
        private Sample mAAngle;
        private Sample mAAngularVelocity;
        private Sample mALoad;

        //B
        private Sample mBAngle;
        private Sample mBAngularVelocity;
        private Sample mBLoad;

        //C
        private Sample mCAngle;
        private Sample mCAngularVelocity;
        private Sample mCLoad;

        //能耗信息
        private Sample mPower;
        private Sample mElectricalEnergy;

        //颤振
        private Event mChatterVibration;

        //是否开始的属性

        
        public LuNanAdapter(int port)
        {
            mAdapter = new Adapter();
            initDataItem();
            addDataItem();
            this.mPort = port;
            mAdapter.Port = mPort;
        }

        private void initLuNanAdapter(int port)
        {
            mAdapter = new Adapter();
            initDataItem();
            addDataItem();
            this.mPort = port;
            mAdapter.Port = mPort;
        }


        public void start()
        {
            mAdapter.Start();
        }

        public void stop()
        {
            mAdapter.Stop();
        }

        public void begin()
        {
            mAdapter.Begin();
        }

        public void sendChanged(string timestamp = null)
        {
            mAdapter.SendChanged(timestamp);
        }

        private void addDataItem()
        {
            mAdapter.AddDataItem(mAvail);
            mAdapter.AddDataItem(mEStop);
            mAdapter.AddDataItem(mControllerMode);
            mAdapter.AddDataItem(mSystemStatus);
            mAdapter.AddDataItem(mSystemMessage);
            mAdapter.AddDataItem(mExecution);
            mAdapter.AddDataItem(mProgram);

            //主轴
            mAdapter.AddDataItem(mSpindleRotaryVelocity);
            mAdapter.AddDataItem(mSpindleLoad);

            //进给
            mAdapter.AddDataItem(mPathFeedrate);

            //x,y,z,a,b,c轴
            //X
            mAdapter.AddDataItem(mXPos);
            mAdapter.AddDataItem(mXAxisFeedrate);
            mAdapter.AddDataItem(mXLoad);

            //Y
            mAdapter.AddDataItem(mYPos);
            mAdapter.AddDataItem(mYAxisFeedrate);
            mAdapter.AddDataItem(mYLoad);

            //Z
            mAdapter.AddDataItem(mZPos);
            mAdapter.AddDataItem(mZAxisFeedrate);
            mAdapter.AddDataItem(mZLoad);

            //A
            mAdapter.AddDataItem(mAAngle);
            mAdapter.AddDataItem(mAAngularVelocity);
            mAdapter.AddDataItem(mALoad);

            //B
            mAdapter.AddDataItem(mBAngle);
            mAdapter.AddDataItem(mBAngularVelocity);
            mAdapter.AddDataItem(mBLoad);

            //C
            mAdapter.AddDataItem(mCAngle);
            mAdapter.AddDataItem(mCAngularVelocity);
            mAdapter.AddDataItem(mCLoad);

            //能耗功率
            mAdapter.AddDataItem(mPower);
            mAdapter.AddDataItem(mElectricalEnergy);
            //颤振
            mAdapter.AddDataItem(mChatterVibration);
        }


        private void initDataItem()
        {
            mAvail = new Event("avail");
            mEStop = new Event("lunan_estop");
            mControllerMode = new Event("lunan_controller_mode");
            mSystemStatus = new Condition("lunan_system_status", true);
            mSystemMessage = new Event("system_message");
            mExecution = new Event("lunan_execution");
            mProgram = new Event("nc_program");

            mSpindleRotaryVelocity = new Sample("lunan_spindle_rotary_velocity");
            mSpindleLoad = new Sample("lunan_spindle_load");

            mPathFeedrate = new Sample("lunan_path_feedrate");

            mXPos = new Sample("machine_xpos");
            mXAxisFeedrate = new Sample("lunan_xvelocity");
            mXLoad = new Sample("lunan_xload");

            mYPos = new Sample("machine_ypos");
            mYAxisFeedrate = new Sample("lunan_yvelocity");
            mYLoad = new Sample("lunan_yload");

            mZPos = new Sample("machine_zpos");
            mZAxisFeedrate = new Sample("lunan_zvelocity");
            mZLoad = new Sample("lunan_zload");

            mAAngle = new Sample("machine_aangle");
            mAAngularVelocity = new Sample("lunan_aangular_velocity");
            mALoad = new Sample("lunan_aload");

            mBAngle = new Sample("machine_bangle");
            mBAngularVelocity = new Sample("lunan_bangular_velocity");
            mBLoad = new Sample("lunan_bload");

            mCAngle = new Sample("machine_cangle");
            mCAngularVelocity = new Sample("lunan_cangular_velocity");
            mCLoad = new Sample("lunan_cload");

            //能耗功率
            mPower = new Sample("lunan_power");
            mElectricalEnergy = new Sample("lunan_electrical_energy");

            //颤振
            mChatterVibration = new Event("lunan_chatter_vibration");
        }


        public void setAvailability(string availability)
        {
            mAvail.Value = availability;
        }

        public void setEStop(string estop)
        {
            mEStop.Value = estop;
        }

        public void setControllerMode(string controllerMode)
        {
            mControllerMode.Value = controllerMode;
        }

        public void setSystemStatus(string systemStatus)
        {
            mSystemStatus.Value = systemStatus;
        }

        public void setSystemMessage(string systemMessage)
        {
            mSystemMessage.Value = systemMessage;
        }

        public void setExecution(string execution)
        {
            mExecution.Value = execution;
        }

        public void setProgram(string program)
        {
            mProgram.Value = program;
        }

        public void setSpindleRotaryVelocity(string spindleRotaryVelocity)
        {
            mSpindleRotaryVelocity.Value = spindleRotaryVelocity;
        }

        public void setSpindleLoad(string spindleLoad)
        {
            mSpindleLoad.Value = spindleLoad;
        }

        public void setPathFeedrate(string pathFeedrate)
        {
            mPathFeedrate.Value = pathFeedrate;
        }

        //X轴
        public void setXPos(string xPos)
        {
            mXPos.Value = xPos;
        }

        public void setXAxisFeedrate(string xAxisFeedrate)
        {
            mXAxisFeedrate.Value = xAxisFeedrate;
        }

        public void setXLoad(string xLoad)
        {
            mXLoad.Value = xLoad;
        }

        //Y轴
        public void setYPos(string yPos)
        {
            mYPos.Value = yPos;
        }

        public void setYAxisFeedrate(string yAxisFeedrate)
        {
            mYAxisFeedrate.Value = yAxisFeedrate;
        }

        public void setYLoad(string yLoad)
        {
            mYLoad.Value = yLoad;
        }

        //Z轴
        public void setZPos(string zPos)
        {
            mZPos.Value = zPos;
        }

        public void setZAxisFeedrate(string zAxisFeedrate)
        {
            mZAxisFeedrate.Value = zAxisFeedrate;
        }

        public void setZLoad(string zLoad)
        {
            mZLoad.Value = zLoad;
        }

        //A轴
        public void setAAngle(string aAngle)
        {
            mAAngle.Value = aAngle;
        }

        public void setAAngularVelocity(string aAngularVelocity)
        {
            mAAngularVelocity.Value = aAngularVelocity;
        }

        public void setALoad(string aLoad)
        {
            mALoad.Value = aLoad;
        }

        //B轴
        public void setBAngle(string bAngle)
        {
            mBAngle.Value = bAngle;
        }

        public void setBAngularVelocity(string bAngularVelocity)
        {
            mBAngularVelocity.Value = bAngularVelocity;
        }

        public void setBLoad(string bLoad)
        {
            mBLoad.Value = bLoad;
        }

        //C轴
        public void setCAngle(string cAngle)
        {
            mCAngle.Value = cAngle;
        }

        public void setCAngularVelocity(string cAngularVelocity)
        {
            mCAngularVelocity.Value = cAngularVelocity;
        }

        public void setCLoad(string cLoad)
        {
            mCLoad.Value = cLoad;
        }

        public void setPower(string power)
        {
            mPower.Value = power;
        }

        public void setElectricalEnergy(string electricalEnergy)
        {
            mElectricalEnergy.Value = electricalEnergy;
        }

        public void setChatterVibration(string chatterVibration)
        {
            mChatterVibration.Value = chatterVibration;
        }

    }
}
