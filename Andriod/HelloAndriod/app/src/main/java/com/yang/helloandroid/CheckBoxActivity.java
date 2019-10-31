package com.yang.helloandroid;

import androidx.appcompat.app.AppCompatActivity;

import android.os.Bundle;
import android.view.View;
import android.view.Menu;
import android.view.MenuItem;
import android.widget.Button;
import android.widget.CheckBox;
import android.widget.CompoundButton;
import android.widget.TextView;

import java.util.ArrayList;

import android.os.Bundle;

public class CheckBoxActivity extends AppCompatActivity implements CompoundButton.OnCheckedChangeListener {
    private CheckBox musicCkb;
    private CheckBox tripCkb;
    private CheckBox filmCkb;
    private CheckBox gameCkb;
    private TextView result_tv;
    private Button endBtn;
    //爱好数组
    ArrayList<String> hobbies = new ArrayList<String>();

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_check_box);
        //初始化控件
        musicCkb = (CheckBox) findViewById(R.id.chb_music);
        tripCkb = (CheckBox) findViewById(R.id.chb_trip);
        filmCkb = (CheckBox) findViewById(R.id.chb_film);
        gameCkb = (CheckBox) findViewById(R.id.chb_game);
        result_tv = (TextView) findViewById(R.id.result_tv);
        endBtn = (Button) findViewById(R.id.end);
        //设置监听器
        musicCkb.setOnCheckedChangeListener(this);
        tripCkb.setOnCheckedChangeListener(this);
        filmCkb.setOnCheckedChangeListener(this);
        gameCkb.setOnCheckedChangeListener(this);
        //为button设置监听器
        endBtn.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {
                StringBuilder sb = new StringBuilder();
                for (int i = 0; i < hobbies.size(); i++) {
                    //把选择的爱好添加到string尾部
                    if (i == (hobbies.size() - 1)) {
                        sb.append(hobbies.get(i));
                    } else {
                        sb.append(hobbies.get(i) + ",");
                    }
                }
                //显示选择结果
                result_tv.setText("你选择了：" + sb);
            }
        });
    }

    @Override
    public void onCheckedChanged(CompoundButton buttonView, boolean isChecked) {
        if (isChecked) {
            //添加到爱好数组
            hobbies.add(buttonView.getText().toString().trim());
        } else {
            //从数组中移除
            hobbies.remove(buttonView.getText().toString().trim());
        }
    }
}