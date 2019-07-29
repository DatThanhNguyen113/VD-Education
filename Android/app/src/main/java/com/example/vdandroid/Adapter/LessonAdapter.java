package com.example.vdandroid.Adapter;

import android.content.Context;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.widget.BaseAdapter;
import android.widget.TextView;

import com.example.vdandroid.Model.LessonModel;
import com.example.vdandroid.R;

import java.util.ArrayList;

public class LessonAdapter extends BaseAdapter {
    ArrayList<Object> list;
    private static final int ITEM = 0;
    private static final int HEADER = 1;
    private LayoutInflater layoutInflater;

    public LessonAdapter(Context context, ArrayList<Object> list) {
        this.list = list;
        layoutInflater = (LayoutInflater) context.getSystemService( Context.LAYOUT_INFLATER_SERVICE );
    }

    @Override
    public int getItemViewType(int position) {
        if (list.get( position ) instanceof LessonModel) {
            return ITEM;
        } else {
            return HEADER;
        }
    }

    @Override
    public int getViewTypeCount() {
        return 2;
    }

    @Override
    public int getCount() {
        return list.size();
    }

    @Override
    public Object getItem(int i) {
        return list.get( i );
    }

    @Override
    public long getItemId(int i) {
        return i;
    }

    @Override
    public View getView(int i, View view, ViewGroup viewGroup) {
        if (view == null) {
            switch (getItemViewType( i )) {
                case ITEM:
                    view = layoutInflater.inflate( R.layout.item_list, null );
                    break;
                case HEADER:
                    view = layoutInflater.inflate( R.layout.item_header, null );
                    break;
            }
        }

        switch (getItemViewType( i )) {
            case ITEM:
                TextView tvLessonName = view.findViewById( R.id.tvLessonName );
                TextView tvRoom = view.findViewById( R.id.tvRoom );
                TextView tvTeacher = view.findViewById( R.id.tvTeacher );
                TextView tvLessonNumber = view.findViewById( R.id.tvLessonNumber );
                tvLessonName.setText( ((LessonModel) list.get( i )).getLessonName() );
                tvRoom.setText( ((LessonModel) list.get( i )).getDescription() );
                break;
            case HEADER:
                TextView itemHeader = view.findViewById( R.id.itemHeader );
                itemHeader.setText( (String)list.get( i ) );
                break;
        }

        return view;
    }
}
