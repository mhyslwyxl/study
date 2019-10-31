package com.yang.helloandroid;

import androidx.appcompat.app.AppCompatActivity;

import android.os.Bundle;
import android.widget.RadioButton;
import android.widget.RadioGroup;
import android.widget.TextView;

public class RadioActivity extends AppCompatActivity {
    private TextView tv_textview5;
    private RadioGroup rg_radiogroup1;
    private RadioButton radiobutton1, radiobutton2, radiobutton3, radiobutton4;

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_radio);

        tv_textview5 = findViewById(R.id.textview5);
        rg_radiogroup1 = findViewById(R.id.radiogroup1);
        radiobutton1 = findViewById(R.id.radiobutton1);
        radiobutton2 = findViewById(R.id.radiobutton2);
        radiobutton3 = findViewById(R.id.radiobutton3);
        radiobutton4 = findViewById(R.id.radiobutton4);
        rg_radiogroup1.setOnCheckedChangeListener(new RadioGroup.OnCheckedChangeListener() {
            @Override
            public void onCheckedChanged(RadioGroup group, int checkedId) {
                String text="我最喜欢运动是";
                if(checkedId==radiobutton1.getId())
                    text+="  音乐";
                else if(checkedId==radiobutton2.getId())
                    text+="  体育";
                else if(checkedId==radiobutton3.getId())
                    text+="  舞蹈";
                else if(checkedId==radiobutton4.getId())
                    text+="  看书";

                tv_textview5.setText(text);
            }
        });

    }
}
