using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LLComm
{
    // MID
    public enum MID
    {
        HEARTBEAT = 1,
        HEARTBEAT_ACK,

        US_UPD,
        WT_UPD,
        TP_UPD,

        DT_TRIGGERED,

        LED_ON,
        LED_OFF,

        CARD_ID,

        START_BEEP,
        STOP_BEEP,

        POWER,

        FAN,

        TP_ENV_UPD,

        INVALID = 0xFF
    }

    // LED
    public enum LED
    {
        HAND = 0,
        MOUTH,
        FACE,
        ALARM_RED,
        ALARM_GREEN,
        DUMMY,

        STEP_1,
        STEP_2,
        STEP_3,
        MARK
    }
}
