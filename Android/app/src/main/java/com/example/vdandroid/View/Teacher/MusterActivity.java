package com.example.vdandroid.View.Teacher;

import android.content.Intent;
import android.os.Bundle;
import android.support.annotation.Nullable;
import android.support.v7.app.AppCompatActivity;
import android.view.View;
import android.widget.Button;
import android.widget.ImageView;
import android.widget.ListView;
import android.widget.TextView;
import android.widget.Toast;

import com.example.vdandroid.Adapter.MusterAdapter;
import com.example.vdandroid.Model.MusterModel;
import com.example.vdandroid.Presenter.MusterTask;
import com.example.vdandroid.Presenter.UpdateMusterTask;
import com.example.vdandroid.R;
import com.example.vdandroid.View.Interface.IViewMuster;
import com.example.vdandroid.View.Interface.IViewUpdateMuster;
import com.google.zxing.integration.android.IntentIntegrator;
import com.google.zxing.integration.android.IntentResult;

import java.util.HashMap;
import java.util.List;
import java.util.Map;

public class MusterActivity extends AppCompatActivity {

    private ListView lvMuster;
    private Button btnCheckIn;
    private TextView tvHeaderLesson;
    public static List<MusterModel> list;
    private MusterAdapter adapter;
    private ImageView imgBackMuster;


    @Override
    protected void onCreate(@Nullable Bundle savedInstanceState) {
        super.onCreate( savedInstanceState );
        setContentView( R.layout.layout_muster );

        onInit();
        onEvent();
        onGetListMuster();
    }

    private void onInit(){
        lvMuster = findViewById( R.id.lvMuster );
        btnCheckIn = findViewById( R.id.btnCheckIn );
        tvHeaderLesson = findViewById( R.id.tvHeaderLesson );
        imgBackMuster = findViewById( R.id.imgBackMuster );
    }

    private void onEvent(){
        imgBackMuster.setOnClickListener( new View.OnClickListener() {
            @Override
            public void onClick(View view) {
                finish();
            }
        } );

        btnCheckIn.setOnClickListener( new View.OnClickListener() {
            @Override
            public void onClick(View view) {
                IntentIntegrator intentIntegrator =new IntentIntegrator( MusterActivity.this );
                intentIntegrator.setDesiredBarcodeFormats( IntentIntegrator.ALL_CODE_TYPES );
                intentIntegrator.setPrompt( "Scan" );
                intentIntegrator.setCameraId( 0 );
                intentIntegrator.setBeepEnabled( false );
                intentIntegrator.setBarcodeImageEnabled( false );
                intentIntegrator.initiateScan();
            }
        } );
    }

    @Override
    public void onActivityResult(int requestCode, int resultCode, Intent data){
        IntentResult result = IntentIntegrator.parseActivityResult( requestCode, resultCode,  data );

        if(result != null){
            if(result.getContents() == null){
                Toast.makeText( this,"Fail to scan ",Toast.LENGTH_LONG ).show();
            }
            else {
                Map<String, String> mMap = new HashMap<>();

                String MSSV = result.getContents();
                for(int i = 0; i < list.size();i++){
                    if(MSSV.equals( list.get( i ).getStudent_id() )){
                        mMap.put( "id", String.valueOf( list.get( i ).getId() ) );
                        mMap.put( "student_id", list.get( i ).getStudent_id() );
                        mMap.put( "timetable_id", String.valueOf( list.get( i ).getTimetable_id() ) );
                        final int finalI = i;
                        new UpdateMusterTask( MusterActivity.this, new IViewUpdateMuster() {
                            @Override
                            public void onSuccess() {
                                list.get( finalI ).setJoin_status( 1 );
                                adapter.notifyDataSetChanged();
                                Toast.makeText( MusterActivity.this, "Success", Toast.LENGTH_SHORT ).show();
                            }

                            @Override
                            public void onFail() {
                                Toast.makeText( MusterActivity.this, "Failed to check in", Toast.LENGTH_SHORT ).show();
                            }
                        },  mMap).execute();
                        break;
                    }
                }
            }
        }
        else
        {
            super.onActivityResult(requestCode, resultCode,  data);
        }

    }

    private void onGetListMuster(){
        new MusterTask( MusterActivity.this, new IViewMuster() {
            @Override
            public void onSuccess() {
                if(list != null){
                    if(list.size() > 0){
                        adapter = new MusterAdapter( MusterActivity.this, R.layout.muster_item, list );
                        lvMuster.setAdapter( adapter );
                        adapter.notifyDataSetChanged();
                        tvHeaderLesson.setText( list.get( 0 ).getSubject_name() );
                    }
                }
            }

            @Override
            public void onFail() {
                Toast.makeText( MusterActivity.this, "Failed to load", Toast.LENGTH_SHORT ).show();
            }
        } ).execute(  );
    }


}
