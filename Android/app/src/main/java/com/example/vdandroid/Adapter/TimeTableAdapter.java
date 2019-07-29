package com.example.vdandroid.Adapter;

import android.content.Context;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.widget.BaseAdapter;
import android.widget.TextView;

import com.example.vdandroid.Model.LessonModel;
import com.example.vdandroid.Model.TimeTableModel;
import com.example.vdandroid.R;

import java.util.ArrayList;

public class TimeTableAdapter extends BaseAdapter {
    ArrayList<Object> list;
    private static final int ITEM = 0;
    private static final int HEADER = 1;
    private LayoutInflater layoutInflater;

    public TimeTableAdapter(Context context, ArrayList<Object> list) {
        this.list = list;
        layoutInflater = (LayoutInflater) context.getSystemService( Context.LAYOUT_INFLATER_SERVICE );
    }

    @Override
    public int getItemViewType(int position) {
        if (list.get( position ) instanceof TimeTableModel) {
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
                String time_start = "";
                TextView tvLessonName = view.findViewById( R.id.tvLessonName );
                TextView tvRoom = view.findViewById( R.id.tvRoom );
                TextView tvTeacher = view.findViewById( R.id.tvTeacher );
                TextView tvLessonNumber = view.findViewById( R.id.tvLessonNumber );
                TextView tvTime = view.findViewById( R.id.tvTime );
                tvLessonName.setText( ((TimeTableModel) list.get( i )).getSubject_name() );
                tvTeacher.setText( ((TimeTableModel) list.get( i )).getTeacher_name() );
                tvRoom.setText( "Phòng " + ((TimeTableModel) list.get( i )).getRoom() );
                tvLessonNumber.setText( "Tiết " + ((TimeTableModel) list.get( i )).getLesson_number() );
                String lesson_number = ((TimeTableModel) list.get( i )).getLesson_number();
                String[] number = lesson_number.split( "," );
                String mLessonStart = number[0];
                switch (mLessonStart) {
                    case "1":
                        time_start = "07:00";
                        break;
                    case "2":
                        time_start = "07:50";
                        break;
                    case "3":
                        time_start = "08:45";
                        break;
                    case "4":
                        time_start = "09:45";
                        break;
                    case "5":
                        time_start = "10:35";
                        break;
                    case "6":
                        time_start = "11:25";
                        break;
                    case "7":
                        time_start = "13:00";
                        break;
                    case "8":
                        time_start = "13:50";
                        break;
                    case "9":
                        time_start = "14:45";
                        break;
                    case "10":
                        time_start = "15:45";
                        break;
                    case "11":
                        time_start = "16:35";
                        break;
                    case "12":
                        time_start = "17:25";
                        break;
                }
                tvTime.setText( time_start );
                break;
            case HEADER:
                TextView itemHeader = view.findViewById( R.id.itemHeader );
                itemHeader.setText( (String) list.get( i ) );
                break;
        }

        return view;
    }
}