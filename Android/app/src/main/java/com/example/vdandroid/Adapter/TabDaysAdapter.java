package com.example.vdandroid.Adapter;

import android.annotation.SuppressLint;
import android.content.Context;
import android.support.annotation.NonNull;
import android.support.annotation.Nullable;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.widget.AdapterView;
import android.widget.ArrayAdapter;
import android.widget.TextView;

import com.example.vdandroid.Model.LessonModel;
import com.example.vdandroid.R;

import java.util.List;

import static android.content.Context.LAYOUT_INFLATER_SERVICE;

public class TabDaysAdapter extends ArrayAdapter<LessonModel> {
    private List<LessonModel> responseList;
    private int resource;
    private LayoutInflater inflater;

    public TabDaysAdapter(@NonNull Context context, int resource, List<LessonModel> objects) {
        super( context, resource, objects );
        responseList = objects;
        this.resource = resource;
        inflater = (LayoutInflater) context.getSystemService( LAYOUT_INFLATER_SERVICE );
    }

    @SuppressLint("WrongConstant")
    @NonNull
    @Override
    public View getView(final int position, @Nullable View convertView, @NonNull ViewGroup parent) {
        ViewHolder holder = null;
        if (convertView == null) {
            holder = new ViewHolder();
            convertView = inflater.inflate( resource, null );
            holder.tvLessonName = convertView.findViewById( R.id.tvLessonName );
            holder.tvLessonDescription =  convertView.findViewById( R.id.tvLessonDescription );
            holder.tvID = convertView.findViewById( R.id.tvID );
            convertView.setTag( holder );
        } else {
            holder = (ViewHolder) convertView.getTag();
        }

        holder.tvLessonName.setText( responseList.get( position ).getLessonName() );
        holder.tvLessonDescription.setText( responseList.get( position ).getDescription() );
        holder.tvID.setText( String.valueOf( position + 1 ) );
        return convertView;
    }

    class ViewHolder {
        private TextView tvLessonName;
        private TextView tvLessonDescription;
        private TextView tvID;

    }
}
