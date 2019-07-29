package com.example.vdandroid.Adapter;

import android.app.Dialog;
import android.content.Context;
import android.content.Intent;
import android.support.annotation.Nullable;
import android.support.design.widget.BottomNavigationView;
import android.support.v4.app.Fragment;
import android.support.v4.app.FragmentActivity;
import android.support.v4.app.FragmentTransaction;
import android.support.v7.app.AppCompatActivity;
import android.support.v7.widget.CardView;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.view.Window;
import android.widget.ArrayAdapter;
import android.widget.Button;
import android.widget.TextView;
import android.widget.Toast;

import com.example.vdandroid.FragmentHome;
import com.example.vdandroid.FragmentLesson;
import com.example.vdandroid.FragmentNotification;
import com.example.vdandroid.Model.NotificationModel;
import com.example.vdandroid.R;
import com.example.vdandroid.View.RegisterSubject.RegisterSubjectActivity;

import java.util.ArrayList;
import java.util.List;

public class NotifyAdapter extends ArrayAdapter<NotificationModel> {
    private Context context;
    private int resource;
    private List<NotificationModel> responseList;
    private BottomNavigationView BottomNavigationView;

    public NotifyAdapter(Context context, int resource, List<NotificationModel> list) {
        super( context, resource, list );
        this.context = context;
        this.resource = resource;
        this.responseList = list;
    }

    @Override
    public View getView(int position, View convertView, ViewGroup parent) {
        ViewHolder viewHolder;
        if (convertView == null) {
            convertView = LayoutInflater.from( context ).inflate( R.layout.notification_item, parent, false );
            viewHolder = new ViewHolder();
            viewHolder.tvHeaderNotification = convertView.findViewById( R.id.tvHeaderNotification );
            viewHolder.tvTime = convertView.findViewById( R.id.tvTime );
            viewHolder.tvBodyNotification = convertView.findViewById( R.id.tvBodyNotification );
            viewHolder.cardView_detailNotify = convertView.findViewById( R.id.cardView_detailNotify );


            convertView.setTag( viewHolder );
        } else {
            viewHolder = (ViewHolder) convertView.getTag();
        }
        final NotificationModel model = responseList.get( position );
        viewHolder.tvHeaderNotification.setText( model.getSubject() );
        viewHolder.tvTime.setText( onSetTitleHeader( model.getCreate_date() ) );
        viewHolder.tvBodyNotification.setText( model.getBody() );

        viewHolder.cardView_detailNotify.setOnClickListener( new View.OnClickListener() {
            @Override
            public void onClick(View view) {
                try {
                    if (model.getType() == 1) {
                        detailNotifi( model.getSubject(), model.getBody() );
                    } else {
                        if (model.getType() == 0) {
                            if (model.getPath().equals( ".SubjectRegister" )) {
                                Intent intent = new Intent( context, RegisterSubjectActivity.class );
                                intent.addFlags( Intent.FLAG_ACTIVITY_NO_ANIMATION );
                                context.startActivity( intent );
                            } else {
                                if (model.getPath().equals( ".TimeTable" )) {
                                    AppCompatActivity activity = (AppCompatActivity) view.getContext();
                                    ((BottomNavigationView) activity.findViewById( R.id.bottom_navigation )).setSelectedItemId( R.id.action_lesson );
                                }
                            }
                        }
                    }
                } catch (Exception ex) {
                    ex.printStackTrace();
                }
            }
        } );
        return convertView;
    }

    public class ViewHolder {
        TextView tvHeaderNotification, tvTime, tvBodyNotification;
        CardView cardView_detailNotify;

    }

    private String onSetTitleHeader(String header) {
        String[] mdate = header.split( "-" );
        String nam = mdate[0];
        String thang = mdate[1];
        String mdate2 = mdate[2].substring( 0, 2 );
        String ngay = mdate2;
        String title = (ngay + "/" + thang + "/" + nam);
        return title;
    }

    private void detailNotifi(String title, String body) {
        final Dialog dialog = new Dialog( context );
        dialog.requestWindowFeature( Window.FEATURE_NO_TITLE );
        dialog.setCancelable( false );
        dialog.setContentView( R.layout.dialog_detail_notify );

        Button btnOK = dialog.findViewById( R.id.btnOK );
        TextView tvTitleDetail = dialog.findViewById( R.id.tvTitleDetail );
        TextView tvBodyDetail = dialog.findViewById( R.id.tvBodyDetail );

        tvTitleDetail.setText( title );
        tvBodyDetail.setText( body );

        btnOK.setOnClickListener( new View.OnClickListener() {
            @Override
            public void onClick(View view) {
                dialog.dismiss();
            }
        } );

        dialog.show();
    }
}

