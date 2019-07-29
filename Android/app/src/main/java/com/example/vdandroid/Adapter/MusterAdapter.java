package com.example.vdandroid.Adapter;

import android.annotation.SuppressLint;
import android.content.Context;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.widget.ArrayAdapter;
import android.widget.Button;
import android.widget.TextView;

import com.example.vdandroid.Model.MusterModel;
import com.example.vdandroid.R;

import java.util.List;

public class MusterAdapter  extends ArrayAdapter<MusterModel> {
    private Context context;
    private int resource;
    private List<MusterModel> responseList;

    public MusterAdapter(Context context, int resource, List<MusterModel> list) {
        super( context, resource, list );
        this.context = context;
        this.resource = resource;
        this.responseList = list;
    }

    @SuppressLint({"NewApi", "ResourceAsColor"})
    @Override
    public View getView(int position, View convertView, ViewGroup parent) {
        ViewHolder viewHolder;
        if (convertView == null) {
            convertView = LayoutInflater.from( context ).inflate( R.layout.muster_item, parent, false );
            viewHolder = new ViewHolder();
            viewHolder.tvMSSV_Muster = convertView.findViewById( R.id.tvMSSV_Muster );
            viewHolder.tvStudentName = convertView.findViewById( R.id.tvStudentName );
            viewHolder.btnRegisterSubject = convertView.findViewById( R.id.btnRegisterSubject );

            convertView.setTag( viewHolder );
        } else {
            viewHolder = (ViewHolder) convertView.getTag();
        }
        MusterModel model = responseList.get( position );
        viewHolder.tvMSSV_Muster.setText( model.getStudent_id() );
        viewHolder.tvStudentName.setText( model.getStudent_name() );
        if(!(model.getJoin_status() == 0)){
            viewHolder.btnRegisterSubject.setText( "Đã điểm danh" );
            viewHolder.btnRegisterSubject.setBackgroundResource( R.drawable.custom_btn_checkin );
            viewHolder.btnRegisterSubject.setTextColor( R.color.colorWhite );
        }

        return convertView;
    }

    public class ViewHolder {
        TextView tvMSSV_Muster, tvStudentName;
        Button btnRegisterSubject;

    }


}

