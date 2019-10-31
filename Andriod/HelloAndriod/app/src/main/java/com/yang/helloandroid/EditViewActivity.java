package com.yang.helloandroid;

import androidx.appcompat.app.AppCompatActivity;

import android.content.res.ColorStateList;
import android.graphics.Color;
import android.graphics.Typeface;
import android.os.Bundle;
import android.text.Editable;
import android.text.TextWatcher;
import android.util.Log;
import android.util.TypedValue;
import android.view.View;
import android.widget.Button;
import android.widget.EditText;
import android.widget.TextView;

public class EditViewActivity extends AppCompatActivity {

    private Button mButton1;
    private EditText mEditview1;
    private TextView mTextview1;

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_edit_view);

        mButton1 = findViewById(R.id.button1);
        mEditview1 = findViewById(R.id.editview1);
        mTextview1 = findViewById(R.id.textview1);

        mButton1.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {
                setTitle("button1 被用户点击了");
                Log.i("widgetDemo", "button1 被用户点击了。");
                mTextview1.setText("这是点击按钮事件");
                mTextview1.setTextColor(Color.GREEN);
                mTextview1.setTextSize(TypedValue.COMPLEX_UNIT_SP, 24);
                mTextview1.setTypeface(Typeface.defaultFromStyle(Typeface.BOLD));
                mEditview1.setText("点击开始了");
                mTextview1.setTextColor(Color.BLUE);
            }
        });

        mEditview1.addTextChangedListener(new TextWatcher() {
            @Override
            public void beforeTextChanged(CharSequence s, int start, int count, int after) {

            }

            @Override
            public void onTextChanged(CharSequence s, int start, int before, int count) {
                String strtext = mEditview1.getText().toString();
                mTextview1.setText(strtext);
            }

            @Override
            public void afterTextChanged(Editable s) {

            }
        });
    }
}
