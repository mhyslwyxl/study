package com.yang.helloandroid;

import androidx.appcompat.app.AppCompatActivity;

import android.app.Activity;
import android.content.Intent;
import android.os.Bundle;
import android.util.Log;
import android.view.View;
import android.view.ViewManager;
import android.widget.Button;

import java.util.HashMap;
import java.util.Map;

public class MainActivity extends AppCompatActivity {
    Button btn_button, btn_checkbox, btn_radio, btn_editview, btn_spinner;

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_main);
        btn_button = (Button) this.findViewById(R.id.btn_button);
        btn_checkbox = (Button) this.findViewById(R.id.btn_checkbox);
        btn_radio = (Button) this.findViewById(R.id.btn_radio);
        btn_editview = findViewById(R.id.btn_editview);
        btn_spinner = findViewById(R.id.btn_spinner);
        setListeners();
    }

    private void setListeners() {
        OnClick onClick = new OnClick();
        btn_button.setOnClickListener(onClick);
        btn_checkbox.setOnClickListener(onClick);
        btn_radio.setOnClickListener(onClick);
        btn_editview.setOnClickListener(onClick);
        btn_spinner.setOnClickListener(onClick);
    }

    class OnClick implements View.OnClickListener {

        @Override
        public void onClick(View v) {
            Intent intent = null;

            switch (v.getId()) {
                case R.id.btn_button:
                    intent = new Intent(MainActivity.this, ButtonActivity.class);
                    break;
                case R.id.btn_checkbox:
                    intent = new Intent(MainActivity.this, CheckBoxActivity.class);
                    break;
                case R.id.btn_radio:
                    intent = new Intent(MainActivity.this, RadioActivity.class);
                    break;
                case R.id.btn_editview:
                    intent = new Intent(MainActivity.this, EditViewActivity.class);
                    break;
                case R.id.btn_spinner:
                    intent = new Intent(MainActivity.this, SpinnerActivity.class);
                    break;
            }

            startActivity(intent);
        }
    }
}
